using QuizApp.Models;

namespace QuizApp
{
    public partial class Form1 : Form
    {
        QuizApiClient? _client;
        private List<QuizQuestion> _questions = new();
        private int _currentIndex = 0;
        private int _score = 0;
        private List<Button> _optionButtons = new();

        public Form1()
        {
            InitializeComponent();

            _optionButtons = new List<Button> { btnOption1, btnOption2, btnOption3, btnOption4 };

            foreach (var btn in _optionButtons)
            {
                btn.Click += OptionButton_Click;
            }

            btnNext.Click += BtnNext_Click;
            button1.Click += Button1_Click; // lada min frågor
        }

        override protected void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _client = QuizApiClient.Create();
        }

        private async void Button1_Click(object? sender, EventArgs e)
        {
            try
            {
                button1.Enabled = false;
                listBox1.Items.Clear();

                if (_client is null)
                {
                    _client = QuizApiClient.Create();
                }

                _questions = await _client.GetQuizQuestionsAsync(5);
                _currentIndex = 0;
                _score = 0;
                lblScore.Text = "Score: 0";
                DisplayCurrentQuestion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load questions: " + ex.Message);
                button1.Enabled = true;
            }
        }

        private void DisplayCurrentQuestion()
        {
            // reseta  mina frågor och visa den nya
            foreach (var b in _optionButtons)
            {
                b.Enabled = true;
                b.Tag = null;
            }

            if (_currentIndex >= _questions.Count)
            {
                ShowResultsAndSave();
                return;
            }

            var q = _questions[_currentIndex];
            // visa i min listbox
            listBox1.Items.Add($"Q{_currentIndex + 1}: {q.Question}");
            labelQuestion.Text = q.Question;

            // gör alla alternativ och förbered dom
            var answers = new List<(string Text, bool IsCorrect)>();
            answers.Add((q.CorrectAnswer, true));
            answers.AddRange(q.IncorrectAnswers.Select(a => (a, false)));

            var rnd = new Random();
            answers = answers.OrderBy(_ => rnd.Next()).ToList();

            for (int i = 0; i < _optionButtons.Count; i++)
            {
                var btn = _optionButtons[i];
                if (i < answers.Count)
                {
                    btn.Text = answers[i].Text;
                    btn.Tag = answers[i].IsCorrect;
                    btn.Visible = true;
                }
                else
                {
                    btn.Visible = false;
                }
            }

            // stänga av next knappen tills frågan har blivit svarad
            btnNext.Enabled = false;
        }

        private void OptionButton_Click(object? sender, EventArgs e)
        {
            if (sender is not Button btn) return;
            if (btn.Tag is not bool isCorrect) return;

            // stänger av alla mina alternativ för frågan
            foreach (var b in _optionButtons) b.Enabled = false;

            if (isCorrect)
            {
                // om frågan är rätt så höjer jag min score och uppdaterar texten
                _score++;
                lblScore.Text = $"Score: {_score}";
                MessageBox.Show("Correct!");
            }
            else
            {
                MessageBox.Show("Incorrect. The correct answer was: " + _questions[_currentIndex].CorrectAnswer);
            }

            btnNext.Enabled = true;
        }

        private void BtnNext_Click(object? sender, EventArgs e)
        {
            _currentIndex++;
            if (_currentIndex < _questions.Count)
            {
                DisplayCurrentQuestion();
            }
            else
            {
                ShowResultsAndSave();
            }
        }

        private void ShowResultsAndSave()
        {
            MessageBox.Show($"Quiz finished. Your score: {_score} / {_questions.Count}");

            try
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "quiz_results.txt");
                var text = $"{DateTime.Now:u} - Score: {_score} / {_questions.Count}\n";
                File.AppendAllText(path, text);
            }
            catch
            {
                // ignorera att skriva i filen för så programmet det håller sig simpelt
            }

            button1.Enabled = true;
        }
    }
}
