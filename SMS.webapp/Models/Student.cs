namespace SMS.webapp.Models;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Country> Country{ get; set; } = new HashSet<Country>();

}
