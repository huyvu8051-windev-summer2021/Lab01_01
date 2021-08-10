using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            List<Student> listStudent = NhapDSSinhVien();
            /* List<Student> listStudent = new List<Student>();
            for(int i = 10; i >= 0; i--)
            {
                Student s = new Student();
                s.StudentID = i.ToString();
                s.FullName = "Huy Vũ " + i;
                s.AverageScore = i + 0.0f;
                if(i % 2 == 0)
                {
                    s.Faculty = "CNTT";
                }
                else
                {
                    s.Faculty = "MMT";
                }
                listStudent.Add(s);
            }
            Student a = new Student();
            a.StudentID = "11";
            a.FullName = "Huy Vũ 11";
            a.AverageScore = 10 + 0.0f;
            a.Faculty = "CNTT";
            listStudent.Add(a);*/

            XuatDSSinhVien(listStudent);
            do
            {
                Console.Write("\n-----MENU CHỨC NĂNG-----");
                Console.Write("\n1. Xuất thông tin SV khoa CNTT");
                Console.Write("\n2. Xuất thông tin SV điểm TB trên 5");
                Console.Write("\n3. Xuất DSSV tăng dần theo điểm");
                Console.Write("\n4. Xuất thông tin SV khoa CNTT, điểm TB trên 5");
                Console.Write("\n5. Xuất thông tin SV khoa CNTT, điểm TB cao nhất");
                Console.Write("\n0. Thoát");
                Console.Write("\nNhập lựa chọn: ");
                int luaChon = int.Parse(Console.ReadLine());

                switch (luaChon)
                {
                    case 1:
                        DSSVThuocCNTT(listStudent);
                        break;
                    case 2:
                        DTBLonHonBang5(listStudent);
                        break;
                    case 3:
                        SXSVDiemTangDan(listStudent);
                        break;
                    case 4:
                        CNTTDTBLonHonBang5(listStudent);
                        break;
                    case 5:
                        CNTTDTBCaoNhat(listStudent);
                        break;
                    default:
                        if (luaChon == 0) return;
                        break;
                }

            } while (true);
        }

        private static void CNTTDTBCaoNhat(List<Student> listStudents)
        {
            Console.WriteLine("\n 1.5 Xuất Danh Sách sinh viên thuộc khoa CNTT có điểm trung bình cao nhất");
            float maximumScore = listStudents.OrderBy(s => s.AverageScore).Reverse().First().AverageScore;
            List<Student> ls = (from s in listStudents
                                where (s.Faculty == "CNTT" && s.AverageScore == maximumScore)
                                select s).ToList();
            if (ls.Count() == 0)
            {
                Console.WriteLine("Không có sinh viên thuộc khoa CNTT");
            }
            else
            {
                XuatDSSinhVien(ls);
            }
        }

        private static void CNTTDTBLonHonBang5(List<Student> listStudents)
        {
            Console.WriteLine("\n 1.4 Xuất Danh Sách sinh viên thuộc khoa CNTT có điểm trung bình lớn hơn bằng 5");
            List<Student> ls = (from s in listStudents
                                where (s.Faculty == "CNTT" && s.AverageScore >= 5)
                                select s).ToList();
            if (ls.Count() == 0)
            {
                Console.WriteLine("Không có sinh viên thuộc khoa CNTT có điểm trung bình lớn hơn bằng 5");
            }
            else
            {
                XuatDSSinhVien(ls);
            }
        }

        private static void DSSVThuocCNTT(List<Student> listStudents)
        {
            Console.WriteLine("\n 1.1 Xuất Danh Sách sinh viên thuộc khoa CNTT");
            List<Student> ls = (from s in listStudents
                                where s.Faculty == "CNTT"
                                select s).ToList();
            if (ls.Count() == 0)
            {
                Console.WriteLine("Không có sinh viên thuộc khoa CNTT");
            }
            else
            {
                XuatDSSinhVien(ls);
            }
        }

        private static void DTBLonHonBang5(List<Student> listStudents)
        {
            Console.WriteLine("\n 1.2 Xuất ra thông tin các sinh viên có điểm TB lớn hơn bằng 5");
            List<Student> listStudentResult = listStudents.Where(p => p.AverageScore >= 5).ToList();
            if (listStudentResult.Count() == 0)
                Console.WriteLine("Không có sinh viên nào có điểm >= 5");
            else
                XuatDSSinhVien(listStudentResult);
        }

        private static void SXSVDiemTangDan(List<Student> listStudents)
        {
            Console.WriteLine("\n 1.3 Sắp xếp sinh viên có điểm tăng dần");

            List<Student> listStudentSort = listStudents.OrderBy(p => p.AverageScore).ToList();
            XuatDSSinhVien(listStudentSort);
        }

        private static List<Student> NhapDSSinhVien()
        {
            List<Student> listStudents = new List<Student>();
            string input = "";
            int N = 0;
            do
            {
                Console.Write("Nhập tổng số sinh viên N =");
                input = Console.ReadLine();
            } while (!IsNumber(input) || int.Parse(input) <= 0);
            N = int.Parse(input);

            Console.WriteLine("\n =====Nhập Danh Sách Sinh Viên=======");
            for(int i = 0; i < N; i++)
            {
                Console.WriteLine("\n - Nhập sinh viên thứ {0}", i + 1);
                Student temp = new Student();
                temp.Input();
                listStudents.Add(temp);
            }
            return listStudents;
        }
        private static void XuatDSSinhVien(List<Student> listStudent)
        {
            Console.WriteLine("====Xuất Danh Sách Sinh Viên====");
            foreach(Student student in listStudent)
            {
                student.Show();
            }
        }
        public static bool IsNumber(string s)
        {
            return Microsoft.VisualBasic.Information.IsNumeric(s);
        }
    }
}
