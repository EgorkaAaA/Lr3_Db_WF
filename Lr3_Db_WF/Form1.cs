using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            int b = 0;
            foreach (var a in db.Tutor)
            {
                b++;
            }
            int i = 1;
            Grid.ColumnCount = 4;
            Grid.RowCount = b + 1;
            Grid.Rows[0].Cells[1].Value = "Фамалия";
            Grid.Rows[0].Cells[2].Value = "Имя";
            Grid.Rows[0].Cells[3].Value = "Отчество";
            Grid.ColumnHeadersVisible = false;


            foreach (var k in db.Tutor)
            {
                Grid.Rows[i].Cells[1].Value = k.Surname;
                Grid.Rows[i].Cells[2].Value = k.Name;
                Grid.Rows[i].Cells[3].Value = k.Patronymic;
                i++;
            }
            DeleteButtom(Grid.RowCount);
        }

        private void manufactureDataGridFill()
        {
            RepEntities db = new RepEntities();
            int b = 0;
            foreach (var a in db.Student)
            {
                b++;
            }
            int i = 1;
            Grid.ColumnCount = 4;
            Grid.RowCount = b + 1;
            Grid.Rows[0].Cells[1].Value = "Фамилия";
            Grid.Rows[0].Cells[2].Value = "Имя";
            Grid.Rows[0].Cells[3].Value = "Отчество";
            Grid.ColumnHeadersVisible = false;


            foreach (var m in db.Student)
            {
                Grid.Rows[i].Cells[1].Value = m.Surname;
                Grid.Rows[i].Cells[2].Value = m.Name;
                Grid.Rows[i].Cells[3].Value = m.Patronymic;
                i++;
            }
            DeleteButtom(Grid.RowCount);
        }

        private void LessonDataGridFill()
        {
            RepEntities db = new RepEntities();
            int b = 0;
            foreach (var a in db.Lesson)
            {
                b++;
            }
            int i = 1;
            Grid.ColumnCount = 5;
            Grid.RowCount = b + 1;
            Grid.Rows[0].Cells[1].Value = "Репетитор";
            Grid.Rows[0].Cells[2].Value = "Ученик";
            Grid.Rows[0].Cells[3].Value = "Предмет";
            Grid.Rows[0].Cells[4].Value = "Длительность";
            Grid.ColumnHeadersVisible = false;


            foreach (var f in db.Lesson)
            {
                Grid.Rows[i].Cells[1].Value = f.Tutor;
                Grid.Rows[i].Cells[2].Value = f.Student;
                Grid.Rows[i].Cells[3].Value = f.Subject;
                Grid.Rows[i].Cells[4].Value = f.Duration;
                i++;
            }
            DeleteButtom(Grid.RowCount);
        }

        private void SubjectDataGridFill()
        {
            RepEntities db = new RepEntities();
            int b = 0;
            foreach (var a in db.Subject)
            {
                b++;
            }
            int i = 1;
            Grid.ColumnCount = 3;
            Grid.RowCount = b + 1;
            Grid.Rows[0].Cells[1].Value = "Название";
            Grid.Rows[0].Cells[2].Value = "Цена";
            Grid.ColumnHeadersVisible = false;


            foreach (var d in db.Subject)
            {
                Grid.Rows[i].Cells[1].Value = d.Name;
                Grid.Rows[i].Cells[2].Value = d.Price;
                i++;
            }
            DeleteButtom(Grid.RowCount);
        }

        private void DeleteButtom(int rowsCount)
        {
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
                        int i = 0;
                        foreach (var a in db.Tutor)
                        {
                            if (i == e.RowIndex - 1)
                            {
                                a.Surname = Grid[1, e.RowIndex].Value.ToString();
                            }
                            i++;
                        }
                        db.SaveChanges();
                        manufactureDataGridFill();
                    }
                    else if (e.ColumnIndex == 2)
                    {
                        int i = 0;
                        foreach (var a in db.Tutor)
                        {
                            if (i == e.RowIndex - 1)
                            {
                                a.Name = Grid[1, e.RowIndex].Value.ToString();
                            }
                            i++;
                        }
                        db.SaveChanges();
                        manufactureDataGridFill();
                    }
                    else if (e.ColumnIndex == 3)
                    {
                        int i = 0;
                        foreach (var a in db.Tutor)
                        {
                            if (i == e.RowIndex - 1)
                            {
                                a.Patronymic = Grid[1, e.RowIndex].Value.ToString();
                            }
                            i++;
                        }
                        db.SaveChanges();
                        TutorDataGridFill();
                    }

                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    if (e.ColumnIndex == 1)
                    {
                        int i = 0;
                        foreach (var a in db.Student)
                        {
                            if (i == e.RowIndex - 1)
                            {
                                a.Surname = Grid[1, e.RowIndex].Value.ToString();
                            }
                            i++;
                        }
                        db.SaveChanges();
                        manufactureDataGridFill();
                    }
                    else if (e.ColumnIndex == 2)
                    {
                        int i = 0;
                        foreach (var a in db.Student)
                        {
                            if (i == e.RowIndex - 1)
                            {
                                a.Name = Grid[1, e.RowIndex].Value.ToString();
                            }
                            i++;
                        }
                        db.SaveChanges();
                        manufactureDataGridFill();
                    }
                    else if (e.ColumnIndex == 3)
                    {
                        int i = 0;
                        foreach (var a in db.Student)
                        {
                            if (i == e.RowIndex - 1)
                            {
                                a.Patronymic = Grid[1, e.RowIndex].Value.ToString();
                            }
                            i++;
                        }
                        db.SaveChanges();
                        manufactureDataGridFill();
                    }
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    if (e.ColumnIndex == 1)
                    {
                        int i = 0;
                        foreach (var a in db.Subject)
                        {
                            if (i == e.RowIndex - 1)
                            {
                                a.Name = Grid[1, e.RowIndex].Value.ToString();
                            }
                            i++;
                        }
                        db.SaveChanges();
                        SubjectDataGridFill();
                    }
                    else if (e.ColumnIndex == 2)
                    {
                        int i = 0;
                        foreach (var a in db.Subject)
                        {
                            if (i == e.RowIndex - 1)
                            {
                                a.Price = Convert.ToInt32(Grid[1, e.RowIndex].Value.ToString());
                            }
                            i++;
                        }
                        db.SaveChanges();
                        SubjectDataGridFill();
                    }
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    if (e.ColumnIndex == 1)
                    {
                        int i = 0;
                        foreach (var a in db.Lesson)
                        {
                            if (i == e.RowIndex - 1)
                            {
                                foreach (var b in db.Tutor)
                                {
                                    if (b.Id == Convert.ToInt32(Grid[1, e.RowIndex].Value.ToString()))
                                    {
                                        a.Tutor = b;
                                    }
                                }
                            }
                            i++;
                        }
                        db.SaveChanges();
                        LessonDataGridFill();
                    }
                    else if (e.ColumnIndex == 2)
                    {
                        int i = 0;
                        foreach (var a in db.Lesson)
                        {
                            if (i == e.RowIndex - 1)
                            {
                                foreach (var b in db.Student)
                                {
                                    if (b.Id == Convert.ToInt32(Grid[1, e.RowIndex].Value.ToString()))
                                    {
                                        a.Student = b;
                                    }
                                }
                            }
                            i++;
                        }
                        db.SaveChanges();
                        LessonDataGridFill();
                    }
                    else if (e.ColumnIndex == 3)
                    {
                        int i = 0;
                        foreach (var a in db.Lesson)
                        {
                            if (i == e.RowIndex - 1)
                            {
                                foreach (var b in db.Subject)
                                {
                                    if (b.Id == Convert.ToInt32(Grid[1, e.RowIndex].Value.ToString()))
                                    {
                                        a.Subject = b;
                                    }
                                }
                            }
                            i++;
                        }
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
                    manufactureDataGridFill();
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
                manufactureDataGridFill();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                Lesson Lesson = new Lesson
                {
                    Duration = textBox1.Text,
                    Tutor = tutorReturn(Convert.ToInt32(textBox2.Text)),
                    Student  = studentReturn(Convert.ToInt32(textBox3.Text)),
                    Subject = subjectReturn(Convert.ToInt32(textBox4.Text))
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
                    int i = 0;
                    Tutor Tutor = new Tutor();
                    foreach (var a in db.Tutor)
                    {
                        if (i == e.RowIndex - 1)
                        {
                            Tutor = a;
                        }
                        i++;

                    }
                    db.Tutor.Remove(Tutor);
                    db.SaveChanges();
                    TutorDataGridFill();
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    int i = 0;
                    Student Student = new Student();
                    foreach (var a in db.Student)
                    {
                        if (i == e.RowIndex - 1)
                        {
                            Student = a;
                        }
                        i++;
                    }
                    db.Student.Remove(Student);
                    db.SaveChanges();
                    manufactureDataGridFill();
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    int i = 0;
                    Lesson Lesson = new Lesson();
                    foreach (var a in db.Lesson)
                    {
                        if (i == e.RowIndex - 1)
                        {
                            Lesson = a;
                        }
                        i++;
                    }
                    db.Lesson.Remove(Lesson);
                    db.SaveChanges();
                    LessonDataGridFill();
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    int i = 0;
                    Subject Subject = new Subject();
                    foreach (var a in db.Subject)
                    {
                        if (i == e.RowIndex - 1)
                        {
                            Subject = a;
                        }
                        i++;
                    }
                    db.Subject.Remove(Subject);
                    db.SaveChanges();
                    SubjectDataGridFill();
                }
            }
        }

        private Tutor tutorReturn(int Id)
        {
            RepEntities db = new RepEntities();
            foreach(var a in db.Tutor)
            {
                if (a.Id == Id)
                    return a;
            }
            return null;
        }

        private Student studentReturn(int Id)
        {
            RepEntities db = new RepEntities();
            foreach (var a in db.Student)
            {
                if (a.Id == Id)
                    return a;
            }
            return null;
        }

        private Subject subjectReturn(int Id)
        {
            RepEntities db = new RepEntities();
            foreach (var a in db.Subject)
            {
                if (a.Id == Id)
                    return a;
            }
            return null;
        }

        private void comboBox1_MouseLeave(object sender, EventArgs e)
        {
            comboBox1_SelectionChangeCommitted(sender, e);
        }
    }
}
