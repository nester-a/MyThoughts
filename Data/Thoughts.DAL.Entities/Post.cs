﻿using Thoughts.DAL.Entities.Base;

namespace Thoughts.DAL.Entities;

public  class Post : Entity
{
    /// <summary>Статус записи</summary>
    public Status Status { get; set; } = null!;

    /// <summary>Дата записи</summary>
    public DateTime Date { get; set; }

    /// <summary>Автор</summary>
    public User User { get; set; }=null!;

    /// <summary>Заголовок записи</summary>
    public string Title { get; set; } = null!;

    /// <summary>Текст (тело) записи</summary>
    public string Body { get; set; } = null!;
    /// <summary>Категория к которой относится запись</summary>
    public Category Category { get; set; } = null!;

    /// <summary>Список тегов относящихся к записи</summary>
    public ICollection<Tag> Tags { get; set; }= new HashSet<Tag>();

    /// <summary>Список комментариев относящихся к записи</summary>
    public ICollection<Comment> Comments { get; set; }= new HashSet<Comment>();

    /// <summary>Признак удалённой записи</summary>
    public bool IsDeleted { get; set; }

    public Post () { }

    public Post (Status status, DateTime date, User user, 
        string title, string body, Category category, bool isDeleted ) 
    { 
        Status = status;
        Date = date;
        User = user;
        Title = title;
        Body = body;
        Category = category;
        IsDeleted = isDeleted;           
    }

    public override string ToString() => $"{Date}, {User.NikName}: {Title}";

}
