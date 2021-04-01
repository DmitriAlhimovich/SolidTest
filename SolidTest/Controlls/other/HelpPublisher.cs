using System;
using System.Collections.Generic;
using System.Text;

namespace SolidTest.Controlls.other
{
    enum TypeOfEvent
    {
        addGroup,
        addStudent, 
        addTeacher,
        addSubject

    }


    class HelpPublisher
    {
        private PublisherCreator PublisherCreator { get; set; }

        public HelpPublisher(PublisherCreator publisherCreator)
        {
            this.PublisherCreator = publisherCreator;
        }

        public string Subscribe(TypeOfEvent typeOfEvent, Action<object> action, string description)
        {          

            switch (typeOfEvent)
            {

                case TypeOfEvent.addGroup:
                    this.PublisherCreator.AddGroupEvent += action;
                    break;
                case TypeOfEvent.addStudent:
                    this.PublisherCreator.AddStudentEvent += action;
                    break;
                case TypeOfEvent.addTeacher:
                    this.PublisherCreator.AddTeacherEvent += action;
                    break;
                case TypeOfEvent.addSubject:
                    this.PublisherCreator.AddSubjectEvent += action;
                    break;
                default:
                    break;
            }

            if (this.PublisherCreator.DictionaryOfHandlers.ContainsKey(typeOfEvent.ToString()))
            {
                return "Вы уже подписаны";
            }
            else
            {
                this.PublisherCreator.DictionaryOfHandlers.Add(typeOfEvent.ToString(), new KeyValuePair<string, Action<object>>(description, action));

                return "подписка оформлена";
            }
        }

        public string ShowAllSubscribtios()
        {
            StringBuilder report = new StringBuilder();

            foreach (var handler in this.PublisherCreator.DictionaryOfHandlers)
            {
                report.Append($"Ключ: {handler.Key} описание: {handler.Value.Key}\n");
            }
            return report.ToString();
        }

        public string UnSubscribe( string keyOfSubscribtion)
        {
            if (this.PublisherCreator.DictionaryOfHandlers.ContainsKey(keyOfSubscribtion))
            {
                string removeEventName = this.PublisherCreator.DictionaryOfHandlers[keyOfSubscribtion].Key;
                Action<object> action = this.PublisherCreator.DictionaryOfHandlers[keyOfSubscribtion].Value;               

                this.PublisherCreator.DictionaryOfHandlers.Remove(keyOfSubscribtion);///// 

                switch (keyOfSubscribtion)
                {

                    case "addGroup":
                        this.PublisherCreator.AddGroupEvent -= action;
                        break;
                    case "addStudent":
                        this.PublisherCreator.AddStudentEvent -= action;

                        break;
                    case "addTeacher":
                        this.PublisherCreator.AddTeacherEvent -= action;
                        break;
                    case "addSubject":
                        this.PublisherCreator.AddSubjectEvent -= action;
                        break;
                    default:
                        break;
                }

                

                return $"Событие {removeEventName} отписано";
            }
            else
            {
                return "нет такой подписки";
            }
        }

    }
}
