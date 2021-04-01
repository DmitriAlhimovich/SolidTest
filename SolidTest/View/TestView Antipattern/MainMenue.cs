using SolidTest.Controlls;
using SolidTest.Controlls.Adders;
using SolidTest.Controlls.other;
using SolidTest.Controlls.Reporter;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolidTest.View
{
    class MainMenue
    {
        private Repository MyRepository { get; set; }
        private Creator Creator { get; set; }//publisher
        private Reader Reader { get; set; }
        private HelpPublisher HelpPublisher { get; set; }


        public Action<object> AddGroupSubscriber { get; set; }//subscriber  addGroup   
        public Action<object> AddStudentSubscriber { get; set; }//subscriber  addStudent 
        public Action<object> AddTeacherSubscriber { get; set; }//subscriber  addTeacher 
        public Action<object> AddSubjectSubscriber { get; set; }//subscriber  addSubject  

        /// <summary>
        /// инициализация
        /// </summary>
        public MainMenue()
        {
            this.MyRepository = Repository.RepositoryBuilder;
            this.Creator = new Creator(MyRepository, new AdderStudent(), new AdderGroup(), new AdderTeacher(), new AdderSubjects());
            this.Reader = new Reader(MyRepository);

            this.HelpPublisher = new HelpPublisher(this.Creator);
            this.AddGroupSubscriber = (a) => Console.WriteLine(a);
            this.AddStudentSubscriber = (a) => Console.WriteLine(a);
            this.AddSubjectSubscriber = (a) => Console.WriteLine(a);
            this.AddTeacherSubscriber = (a) => Console.WriteLine(a);

            this.Creator.CreateGroup("A");
            this.Creator.CreateGroup("B");
            this.Creator.CreateStudent("Liosha", "Molovski");
            this.Creator.CreateStudent("Dima", "Kosochkin");
            this.Creator.CreateTeacher("Gennadi", "Maspanaw", 1);
            this.Creator.CreateTeacher("Kirill", "Machulo", 3);
            this.Creator.CreateSubjects("Math");
            this.Creator.CreateSubjects("Biology");
        }





        public void Start()// главное меню
        {

            while (true)
            {

                Console.WriteLine($"\n1 - Создание элементов\n2 - Просмотр элементов\n3 - Изменение элементов\n4 - Удаление элементов\n" +
                    $"5 - Подписаться на обновления\n6 - Отписаться от обновлений\n7 - Просмотр подписок\n22 -Выйти из программы");

                int.TryParse(Console.ReadLine(), out int modeOfMenue);

                switch (modeOfMenue)
                {
                    case 1:
                        {
                            Console.Clear();
                            SubMenuCreateElement();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            SubMenuShowElements();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("Empty");

                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine("Empty");
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            SubMenuSubscribeToEvent();
                            break;

                        }
                    case 6:
                        {
                            Console.Clear();
                            Console.WriteLine(this.HelpPublisher.ShowAllSubscribtios());
                            Console.WriteLine("Введите key подписки для удаления");
                            string key = Console.ReadLine();
                            Console.WriteLine(this.HelpPublisher.UnSubscribe(key));                         
                            break;
                        }
                    case 7:
                        {
                            Console.Clear();
                            Console.WriteLine($"имеющиеся подписки:");
                            Console.WriteLine(this.HelpPublisher.ShowAllSubscribtios());

                            break;
                        }


                    case 22:
                        {
                            return;
                        }


                    default:
                        break;
                }
            }

        }

        private void SubMenuCreateElement()
        {
            Console.WriteLine("Подменю 'создать элемен'");

            while (true)
            {
                Console.WriteLine($"\n1 - Создать группу\n2 - Создать студента\n3 - Создать учителя\n4 - Создать предметы\n" +
                    $"22 - Выйти из программы");

                int.TryParse(Console.ReadLine(), out int modeOfMenue);

                switch (modeOfMenue)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine("Введите номер группы->");
                            this.Creator.CreateGroup(Console.ReadLine());

                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("Введите имя ученика->");
                            string name = Console.ReadLine();
                            Console.WriteLine("Введите фамилию ученика->");
                            string surename = Console.ReadLine();
                            this.Creator.CreateStudent(name, surename);

                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("Введите имя учителя->");
                            string name = Console.ReadLine();
                            Console.WriteLine("Введите фамилию учителя->");
                            string surename = Console.ReadLine();
                            Console.WriteLine("Введите категорию учителя->");
                            int.TryParse(Console.ReadLine(), out int category);
                            this.Creator.CreateTeacher(name, surename, category);

                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine("Введите имя предмета->");
                            string name = Console.ReadLine();
                            this.Creator.CreateSubjects(name);
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            SubMenuSubscribeToEvent();
                            break;
                        }


                    case 22:
                        {
                            return;
                        }

                    default:
                        break;
                }
            }
        }


        private void SubMenuShowElements()
        {
            Console.WriteLine("Подменю 'посмотреть элементы'");

            while (true)
            {
                Console.WriteLine($"\n1 - Посмотреть группы\n2 - Посмотреть студентов\n3 - Посмотреть учителей\n4 - Посмотреть предмеns\n" +
                    $"5 - Посмотреть подписки\n22 -Выйти из программы");

                int.TryParse(Console.ReadLine(), out int modeOfMenue);

                switch (modeOfMenue)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine(this.Reader.ShowInfo(new GroupsInfo()));

                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine(this.Reader.ShowInfo(new StudentsInfo()));

                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine(this.Reader.ShowInfo(new TeachersInfo()));

                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine(this.Reader.ShowInfo(new SubjectInfo()));
                            return;
                        }
                    case 5:
                        {
                            break;
                        }
                    case 22:
                        {
                            return;
                        }


                    default:
                        break;
                }
            }
        }

        private void SubMenuSubscribeToEvent()
        {
            Console.WriteLine("Подменю 'подписки'");

            while (true)
            {
                Console.WriteLine($"\n1 - Подписаться на создание группы\n2 - Подписаться на создание студентов\n3 - Подписаться на создание учителей\n4 - Подписаться на создание предметов\n" +
                    $"22 -Выйти из программы");

                int.TryParse(Console.ReadLine(), out int modeOfMenue);

                switch (modeOfMenue)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine(this.HelpPublisher.Subscribe(TypeOfEvent.addGroup,this.AddGroupSubscriber, "Оповещение о создании группы"));                         

                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine(this.HelpPublisher.Subscribe(TypeOfEvent.addStudent,this.AddStudentSubscriber, "Оповещение о создании студента"));

                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine(this.HelpPublisher.Subscribe(TypeOfEvent.addTeacher,this.AddTeacherSubscriber, "Оповещение о создании учителя"));

                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine(this.HelpPublisher.Subscribe(TypeOfEvent.addSubject, this.AddTeacherSubscriber, "Оповещение о создании предмета"));
                            break;
                        }

                    case 22:
                        {
                            return;
                        }


                    default:
                        break;
                }
            }
        }


    }
}
