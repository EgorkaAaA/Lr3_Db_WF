using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lr3_Db_WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Invisible();
        }

        private void Invisible()
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
        }

        private void TutorDataGridFill()
        {

            RepEntities db = new RepEntities();
            db.Tutor.Load();
            Grid.DataSource = db.Tutor.Local.ToBindingList();
            DeleteButtom(Grid.RowCount);
            Grid.Columns[1].HeaderText = "Фамилия";
            Grid.Columns[2].HeaderText = "Имя";
            Grid.Columns[3].HeaderText = "Отчество";

        }

        private void DataGridFill()
        {
            RepEntities db = new RepEntities();
            db.Student.Load();
            Grid.DataSource = db.Student.Local.ToBindingList();
            DeleteButtom(Grid.RowCount);
            Grid.Columns[1].HeaderText = "Фамилия";
            Grid.Columns[2].HeaderText = "Имя";
            Grid.Columns[3].HeaderText = "Отчество";
        }

        private void LessonDataGridFill()
        {
            RepEntities db = new RepEntities();
            db.Lesson.Load();
            Grid.DataSource = db.Lesson.Local.ToBindingList();
            DeleteButtom(Grid.RowCount);
            Grid.Columns[1].HeaderText = "Репетитор";
            Grid.Columns[2].HeaderText = "Ученик";
            Grid.Columns[3].HeaderText = "Предмет";
            Grid.Columns[4].HeaderText = "Длительность";
        }

        private void SubjectDataGridFill()
        {
            RepEntities db = new RepEntities();
            db.Subject.Load();
            Grid.DataSource = db.Subject.Local.ToBindingList();
            DeleteButtom(Grid.RowCount);
            Grid.Columns[1].HeaderText = "Название";
            Grid.Columns[2].HeaderText = "Цена";
        }

        private void DeleteButtom(int rowsCount)
        {
            Grid.Columns[0].HeaderText = "Удалить";
            for (int i = 1; i < rowsCount; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                Grid[0, i] = linkCell;
                Grid[0, i].Value = "Удалить";
            }
        } 

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        { 
            RepEntities db = new RepEntities();
            if (checkBox1.Checked)
                if (comboBox1.SelectedIndex == 0)
                {
                    if (e.ColumnIndex == 1)
                    {
                        Tutor tutor = db.Tutor.Find(e.RowIndex);
                        tutor.Surname = Grid[e.ColumnIndex, e.RowIndex].Value.ToString();
                        db.SaveChanges();
                        DataGridFill();
                    }
                    else if (e.ColumnIndex == 2)
                    {
                        Tutor tutor = db.Tutor.Find(e.RowIndex);
                        tutor.Name = Grid[e.ColumnIndex, e.RowIndex ].Value.ToString();
                        db.SaveChanges();
                        DataGridFill();
                    }
                    else if (e.ColumnIndex == 3)
                    {
                        Tutor tutor = new Tutor();
                        tutor = db.Tutor.Find(e.RowIndex);
                        tutor.Patronymic = Grid[e.ColumnIndex, e.RowIndex].Value.ToString();
                        db.SaveChanges();
                        TutorDataGridFill();
                    }

                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    if (e.ColumnIndex == 1)
                    {
                        Student student = db.Student.Find(e.RowIndex);
                        student.Surname = Grid[e.ColumnIndex, e.RowIndex].Value.ToString();
                        db.SaveChanges();
                        DataGridFill();
                    }
                    else if (e.ColumnIndex == 2)
                    {
                        Student student = db.Student.Find(e.RowIndex);
                        student.Name = Grid[e.ColumnIndex, e.RowIndex].Value.ToString();
                        db.SaveChanges();
                        DataGridFill();
                    }
                    else if (e.ColumnIndex == 3)
                    {
                        Student student = db.Student.Find(e.RowIndex );
                        student.Patronymic = Grid[e.ColumnIndex, e.RowIndex].Value.ToString();
                        db.SaveChanges();
                        DataGridFill();;
                    }
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    if (e.ColumnIndex == 1)
                    {
                        Subject subject = db.Subject.Find(e.RowIndex);
                        subject.Name = Grid[e.ColumnIndex, e.RowIndex].Value.ToString();
                        db.SaveChanges();
                        SubjectDataGridFill();
                    }
                    else if (e.ColumnIndex == 2)
                    {
                        Subject subject = db.Subject.Find(e.RowIndex);
                        subject.Price = Convert.ToInt32(Grid[e.ColumnIndex, e.RowIndex].Value.ToString());
                        db.SaveChanges();
                        SubjectDataGridFill();
                    }
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    if (e.ColumnIndex == 1)
                    {
                        Lesson lesson = db.Lesson.Find(e.RowIndex);
                        lesson.Tutor = db.Tutor.Find(Convert.ToInt32(Grid[e.ColumnIndex, e.RowIndex].Value.ToString()));
                        db.SaveChanges();
                        LessonDataGridFill();
                    }
                    else if (e.ColumnIndex == 2)
                    {
                        Lesson lesson = db.Lesson.Find(e.RowIndex);
                        lesson.Student = db.Student.Find(Convert.ToInt32(Grid[e.ColumnIndex, e.RowIndex].Value.ToString()));
                        db.SaveChanges();
                        LessonDataGridFill();
                    }
                    else if (e.ColumnIndex == 3)
                    {
                        Lesson lesson = db.Lesson.Find(e.RowIndex);
                        lesson.Subject = db.Subject.Find(Convert.ToInt32(Grid[e.ColumnIndex, e.RowIndex].Value.ToString()));
                        db.SaveChanges();
                        LessonDataGridFill();
                    }
                    else if(e.ColumnIndex == 4)
                    {
                        Lesson lesson = db.Lesson.Find(e.RowIndex );
                        lesson.Duration = Grid[e.ColumnIndex, e.RowIndex].Value.ToString();
                        db.SaveChanges();
                        LessonDataGridFill();
                    }
                }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
                if (comboBox1.SelectedIndex == 0)
                {
                    Invisible();
                    TutorDataGridFill();
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label1.Text = "Фамилия";
                    label2.Text = "Имя";
                    label3.Text = "Отчество";
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    Invisible();
                    DataGridFill();
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label1.Text = "Фамилия";
                    label2.Text = "Имя";
                    label3.Text = "Отчество";
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    Invisible();
                    LessonDataGridFill();
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    label1.Text = "Репетитор";
                    label2.Text = "Ученик";
                    label3.Text = "Дисцеплина";
                    label4.Text = "Длительность";
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    Invisible();
                    SubjectDataGridFill();
                    label1.Visible = true;
                    label2.Visible = true;
                    label1.Text = "Название";
                    label2.Text = "Цена";
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RepEntities db = new RepEntities();
            if (comboBox1.SelectedIndex == 0)
            {
                Tutor Tutor = new Tutor 
                {
                    Surname = textBox1.Text,
                    Name = textBox2.Text,
                    Patronymic = textBox3.Text
                };
                db.Tutor.Add(Tutor);
                db.SaveChanges();
                TutorDataGridFill();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                Student Student = new Student
                {
                    Surname = textBox1.Text,
                    Name = textBox2.Text,
                    Patronymic = textBox3.Text
                };
                db.Student.Add(Student);
                db.SaveChanges();
                DataGridFill();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                Lesson Lesson = new Lesson
                {
                    Duration = textBox1.Text,
                    Tutor = db.Tutor.Find(Convert.ToInt32(textBox1.Text)),
                    Student  = db.Student.Find(Convert.ToInt32(textBox3.Text)),
                    Subject = db.Subject.Find(Convert.ToInt32(textBox4.Text))
                };
                
                LessonDataGridFill();
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                Subject Subject = new Subject
                {
                    Name = textBox1.Text,
                    Price = Convert.ToInt32(textBox2.Text),
                };
                db.Subject.Add(Subject);
                db.SaveChanges();
                SubjectDataGridFill();
            }
        }

        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RepEntities db = new RepEntities();
            if (e.ColumnIndex == 0)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    Tutor Tutor = new Tutor();
                    Tutor = db.Tutor.Find(e.RowIndex);
                    db.Tutor.Remove(Tutor);
                    db.SaveChanges();
                    TutorDataGridFill();
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    Student Student = new Student();
                    Student = db.Student.Find(e.RowIndex);
                    db.Student.Remove(Student);
                    db.SaveChanges();
                    DataGridFill();
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    Lesson Lesson = new Lesson();
                    Lesson = db.Lesson.Find(e.RowIndex);
                    db.Lesson.Remove(Lesson);
                    db.SaveChanges();
                    LessonDataGridFill();
                }
                else if (comboBox1.SelectedIndex == 3)
                { 
                    Subject Subject = new Subject();
                    Subject = db.Subject.Find(e.RowIndex);
                    db.Subject.Remove(Subject);
                    db.SaveChanges();
                    SubjectDataGridFill();
                }
            }
        }

        private void comboBox1_MouseLeave(object sender, EventArgs e)
        {
            comboBox1_SelectionChangeCommitted(sender, e);
        }
    }
}
