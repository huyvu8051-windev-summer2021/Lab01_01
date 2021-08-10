using System;
using System.Collections.Generic;
using System.Text;

namespace Lab01
{
    class Student
    {
        //1. Tao thuoc tinh
        private string studentID; //mã số sinh viên
        private string fullName; // họ tên sinh viên
        private float averageScore; //điểm trung bình
        private string faculty; //khoa
                                //2. Tao cac Property (tip: chọn Quick Actions And Refactorings từ thuộc tính)
        public string StudentID
        {
            get
            {
                return studentID;
            }
            set
            {
                studentID = value;
            }
        }
        public string FullName
        {
            get
            {
                return fullName;
            }
            set
            {
                fullName = value;
            }

        }
        public float AverageScore
        {
            get
            {
                return averageScore;
            }
            set
            {
                averageScore = value;
            }
        }
        public string Faculty
        {
            get
            {
                return faculty;
            }
            set
            {
                faculty = value;
            }
        }
        // 3. Tao constructor mặc định không tham số
        public Student()
        {
        }
        // 4. Tao constuctor có tham số
        public Student(string id, string name, float score, string faculty)
        {
            StudentID = id;
            FullName = name;
            AverageScore = score;
            Faculty = faculty;
        }
        // 5. Viết các phương thức nhập, xuất sinh viên
        public void Input()
        {
            Console.Write("Nhập MSSV:");
            StudentID = Console.ReadLine();
            Console.Write("Nhập Họ tên Sinh viên:");
            FullName = Console.ReadLine();

            string input = "";
            do
            {
                Console.Write("Nhập Điểm TB:");
                input = Console.ReadLine();
            } while (!IsNumber(input) || float.Parse(input) <= 0f);
            
            AverageScore = float.Parse(input); //ép sang kiểu float

            Console.Write("Nhập Khoa:");
            Faculty = Console.ReadLine();
        }
        public void Show()
        {
            Console.WriteLine("MSSV:{0} Họ Tên:{1} Khoa:{2} ĐiêmTB:{3}", this.StudentID,
            this.fullName, this.Faculty, this.AverageScore);
        }
        public bool IsNumber(string s)
        {
            return Microsoft.VisualBasic.Information.IsNumeric(s);
        }
    }
}
