using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SharpPractice
{
    public class Student
    {
        public string Name;
        public int Age;
        public char Group;
        public bool HasScgolarship;
        public float AverageGradePoint;

        public Student(string Name, int age, char group, bool hasScolarship, float averageGradePoint)
        {
            this.Name = Name;
            Age = age;
            Group = group;
            HasScgolarship = hasScolarship;
            AverageGradePoint = averageGradePoint;
        }

        public void ShowInfo()
        {
            string scolarship;

            if (HasScgolarship)
            {
                scolarship = "есть";
            }
            else
            {
                scolarship = "отсутствует";
            }

            Console.WriteLine($"{Name}, {Age} года, группа \"{Group}\", стипендия {scolarship}, средний бал - {AverageGradePoint};");
        }
    }

    class BaseArticle
    {
        public string Title;

        public BaseArticle(string title)
        {
            Title = title;
        }
    }

    class SimpleArticle : BaseArticle
    {
        public string Slug;

        public SimpleArticle(string title = "Простая статья", string slug = "simple-article") : base(title)
        {
            Slug = slug;
        }
    }

    class PrivateArticle : BaseArticle
    {
        private string _slug;
        private DateTime _publishedDate;
        private int _countOfViews;

        public string Slug { get; private set; }
        public DateTime PublishedDate { get; private set; }
        public int CountOfViews
        {
            get
            {
                return _countOfViews;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Число просмотров не может быть отрицательным", nameof(_countOfViews));
                }
                else if (value.GetType() != typeof(int))
                {
                    throw new InvalidCastException("Число просмотров должно быть целым числом");
                }
                else
                {
                    _countOfViews = value;
                }
            }
        }

        public PrivateArticle(string title, string slug, DateTime publishedDate, int countOfViews) : base(title)
        {
            Slug = slug;
            PublishedDate = publishedDate;
            CountOfViews = countOfViews;
        }

    }


    class Article : BaseArticle
    {
        public string Slug;
        public DateTime PublishedDate;
        public int CountOfViews;

        public Article(DateTime publishedDate, string title = "", string slug = "slug-1", int countOfViews = 0) : base(title)
        {
            Slug = slug;
            PublishedDate = publishedDate;
            CountOfViews = countOfViews;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Title}, слаг: {Slug}, опубликована {PublishedDate}, число просмотров: {CountOfViews};");
        }
    }
}
