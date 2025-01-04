using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

public class ApplicationContext : DbContext
{
    public DbSet<SubscriptionType> subscriptions { get; set; } = null!;
    public DbSet<SubscriberType> subscribers { get; set; } = null!;
    public DbSet<JournalType> journals { get; set; } = null!;
    public DbSet<LitType> literatureoragnizations { get; set; } = null!;
    public DbSet<Type5> statusesofsubscription { get; set; } = null!;
    public DbSet<Type4> statusesofdelivery { get; set; } = null!;
    public DbSet<Type3> namesofjournals { get; set; } = null!;
    public DbSet<Type2> typesofjournals { get; set; } = null!;
    public DbSet<Type1> typesoforganizations { get; set; } = null!;
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
    {
        Database.EnsureCreated();
    }
}
public class Type1
{
    [Column("id")]
    public int id { get; set; }
    public string? type { get; set; }
    public override string ToString()
    {
        return $"{id} {type}";
    }
}
public class Type2
{
    [Column("id")]
    public int id { get; set; }
    public string? type { get; set; }
    public override string ToString()
    {
        return $"{id} {type}";
    }
}
public class Type3
{
    [Column("id")]
    public int id { get; set; }
    public string? type { get; set; }
    public override string ToString()
    {
        return $"{id} {type}";
    }
}
public class Type4
{
    [Column("id")]
    public int id { get; set; }
    public string? type { get; set; }
    public override string ToString()
    {
        return $"{id} {type}";
    }
}
public class Type5
{
    [Column("id")]
    public int id { get; set; }
    public string? type { get; set; }
    public override string ToString()
    {
        return $"{id} {type}";
    }
}
public class LitType
{
    [Column("id")]
    public int Id { get; set; }
    [Column("idoftype")]
    public int IdOfType { get; set; }
    [Column("name")]
    public string? name { get; set; }
    public override string ToString()
    {
        return $"{Id} {IdOfType} {name}";
    }
}
public class JournalType
{
    [Column("id")]
    public int id { get; set; }
    public int countofsubs { get; set; }
    public int idoforg { get; set; }
    public int idofname { get; set; }
    public int idoftype { get; set; }
    public override string ToString()
    {
        return $"{id} {countofsubs} {idoforg} {idofname} {idoftype}";
    }
}
public class SubscriberType
{
    [Column("id")]
    public int id { get; set; }
    public string surname { get; set; }
    public string name { get; set; }
    public string patronymic { get; set; }
    public string street { get; set; }
    public int numberofhouse { get; set; }
    public int numberofapartment { get; set; }
    public string litera { get; set; }
    public override string ToString()
    {
        return $"{id} {surname} {name} {patronymic} {street} {numberofhouse} {numberofapartment} {litera}";
    }
}
public class SubscriptionType
{
    [Column("id")]
    public int id { get; set; }
    public DateTime dateofend { get; set; }
    public DateTime dateofdelivery { get; set; }
    public int idofstatusdelivery { get; set; }
    public int idofstatussubs { get; set; }
    public int idofjournal { get; set; }
    public int idofsubscriber { get; set; }
    public override string ToString()
    {
        return $"{id} {dateofend} {dateofdelivery} {idofstatusdelivery} {idofstatussubs} {idofjournal} {idofsubscriber}";
    }
}