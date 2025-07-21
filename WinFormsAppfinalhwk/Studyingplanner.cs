using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormsAppfinalhwk
{
    public partial class StudyingPlanner : Form
    {
        private List<TodoItem> _todayTodos;
        private List<ExamItem> _upcomingExams;
        private AILearningPlanner _aiPlanner;

        public StudyingPlanner(List<TodoItem> todayTodos, List<ExamItem> upcomingExams)
        {
            InitializeComponent();
            _todayTodos = todayTodos;
            _upcomingExams = upcomingExams;
            _aiPlanner = new AILearningPlanner();

            // 统一风格设置
            var screen = Screen.PrimaryScreen ?? Screen.AllScreens[0];
            int screenWidth = screen.WorkingArea.Width;
            int screenHeight = screen.WorkingArea.Height;
            this.Size = new Size(screenWidth * 2 / 3, screenHeight * 2 / 3);
            this.StartPosition = FormStartPosition.CenterScreen;
            try
            {
                this.BackgroundImage = Image.FromFile(@"C:\WinFormApp\WinFormsAppfinalhwk\background4.jpg");
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch { }

            btnRefreshPlan.BackColor = Color.Gold;
            btnRefreshPlan.FlatAppearance.BorderSize = 0;
            btnRefreshPlan.FlatStyle = FlatStyle.Flat;
            btnRefreshPlan.Font = new Font("楷体", 14F, FontStyle.Bold);
            btnRefreshPlan.ForeColor = Color.LightCoral;

            btnSavePlan.BackColor = Color.Gold;
            btnSavePlan.FlatAppearance.BorderSize = 0;
            btnSavePlan.FlatStyle = FlatStyle.Flat;
            btnSavePlan.Font = new Font("楷体", 14F, FontStyle.Bold);
            btnSavePlan.ForeColor = Color.LightCoral;

            LoadStudyPlan();
        }

        private void LoadStudyPlan()
        {
            var studyPlan = _aiPlanner.GenerateStudyPlan(_todayTodos, _upcomingExams);
            DisplayStudyPlan(studyPlan);
            DisplayPlanSummary(studyPlan);
        }

        private void DisplayStudyPlan(List<StudySession> studyPlan)
        {
            dgvStudyPlan.Rows.Clear();
            foreach (var session in studyPlan)
            {
                dgvStudyPlan.Rows.Add(
                    session.TimeSlot,
                    session.Subject,
                    session.Task,
                    session.Duration,
                    session.Priority,
                    session.Description
                );
            }
            // 设置列标题为中文（可选，建议在Designer里直接设置HeaderText）
            dgvStudyPlan.Columns[0].HeaderText = "时间段";
            dgvStudyPlan.Columns[1].HeaderText = "科目";
            dgvStudyPlan.Columns[2].HeaderText = "任务";
            dgvStudyPlan.Columns[3].HeaderText = "时长(分钟)";
            dgvStudyPlan.Columns[4].HeaderText = "优先级";
            dgvStudyPlan.Columns[5].HeaderText = "描述";
        }

        private void DisplayPlanSummary(List<StudySession> studyPlan)
        {
            int totalMinutes = studyPlan.Sum(s => s.Duration);
            double totalHours = Math.Round(totalMinutes / 60.0, 1);
            var subjectSummary = studyPlan
                .GroupBy(s => s.Subject)
                .ToDictionary(g => g.Key, g => g.Sum(s => s.Duration));

            StringBuilder summary = new StringBuilder();
            summary.AppendLine($"今日学习计划摘要：");
            summary.AppendLine($"总学习时长：{totalHours}小时");
            summary.AppendLine($"科目分配：");
            foreach (var item in subjectSummary)
            {
                summary.AppendLine($"- {item.Key}：{item.Value}分钟");
            }
            txtSummary.Text = summary.ToString();
        }

        private void btnRefreshPlan_Click(object sender, EventArgs e)
        {
            LoadStudyPlan();
            MessageBox.Show("已根据最新数据更新学习计划", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSavePlan_Click(object sender, EventArgs e)
        {
            // 可扩展：保存到数据库或文件
            MessageBox.Show("学习计划已保存", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    // AI学习计划生成器
    public class AILearningPlanner
    {
        public List<StudySession> GenerateStudyPlan(List<TodoItem> todos, List<ExamItem> exams)
        {
            var prioritizedExams = PrioritizeExams(exams);
            var prioritizedTodos = PrioritizeTodos(todos);
            return CreateTimeSlots(prioritizedExams, prioritizedTodos);
        }

        private List<ExamItem> PrioritizeExams(List<ExamItem> exams)
        {
            return exams.OrderBy(e => e.DaysUntilExam)
                        .ThenByDescending(e => e.Importance)
                        .ToList();
        }

        private List<TodoItem> PrioritizeTodos(List<TodoItem> todos)
        {
            return todos.OrderBy(t => t.DueDate)
                        .ThenByDescending(t => t.Priority)
                        .ToList();
        }

        private List<StudySession> CreateTimeSlots(List<ExamItem> exams, List<TodoItem> todos)
        {
            List<StudySession> sessions = new List<StudySession>();
            List<string> timeSlots = new List<string>
            {
                "08:00 - 10:00", "10:15 - 12:00",
                "14:00 - 16:00", "16:15 - 18:00",
                "19:30 - 21:30", "21:45 - 23:00"
            };
            int slotIndex = 0;

            foreach (var exam in exams)
            {
                if (slotIndex >= timeSlots.Count) break;
                int duration = exam.DaysUntilExam <= 2 ? 120 : 90;
                sessions.Add(new StudySession
                {
                    TimeSlot = timeSlots[slotIndex],
                    Subject = exam.Subject,
                    Task = $"复习{exam.Subject}，准备{exam.DaysUntilExam}天后的考试",
                    Duration = duration,
                    Priority = exam.DaysUntilExam <= 3 ? "高" : "中",
                    Description = $"重点复习：{exam.KeyTopics}"
                });
                slotIndex++;
            }

            foreach (var todo in todos)
            {
                if (slotIndex >= timeSlots.Count) break;
                int duration = todo.IsComplex ? 90 : 60;
                sessions.Add(new StudySession
                {
                    TimeSlot = timeSlots[slotIndex],
                    Subject = todo.Subject,
                    Task = todo.TaskContent,
                    Duration = duration,
                    Priority = todo.Priority,
                    Description = $"截止日期：{todo.DueDate:yyyy-MM-dd}"
                });
                slotIndex++;
            }

            while (slotIndex < timeSlots.Count)
            {
                var subject = exams.Any() ? exams.First().Subject : "自主学习";
                sessions.Add(new StudySession
                {
                    TimeSlot = timeSlots[slotIndex],
                    Subject = subject,
                    Task = "自主复习与练习",
                    Duration = 90,
                    Priority = "中",
                    Description = "巩固已学知识，完成练习题目"
                });
                slotIndex++;
            }
            return sessions;
        }
    }

    // 数据结构
    public class StudySession
    {
        public string TimeSlot { get; set; }
        public string Subject { get; set; }
        public string Task { get; set; }
        public int Duration { get; set; }
        public string Priority { get; set; }
        public string Description { get; set; }
    }

    public class TodoItem
    {
        public string TaskContent { get; set; }
        public string Subject { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; }
        public bool IsComplex { get; set; }
    }

    public class ExamItem
    {
        public string Subject { get; set; }
        public int DaysUntilExam { get; set; }
        public string Importance { get; set; }
        public string KeyTopics { get; set; }
    }
}