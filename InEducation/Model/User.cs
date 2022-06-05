using System;

namespace InEducation.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }

        public User(int id, string surname, string name, string patronymic, DateTime birthday)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Birthday = birthday;
        }
    }
}
