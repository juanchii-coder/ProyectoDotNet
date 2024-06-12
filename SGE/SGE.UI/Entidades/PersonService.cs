using System.Collections.Generic;
using System.Threading.Tasks;

public class PersonService
{
    public async Task<List<Person>> GetPersons()
    {
        // This would normally fetch from a database
        return new List<Person>
        {
            new Person { Id = 1, FullName = "John Doe" },
            new Person { Id = 2, FullName = "Jane Smith" },
            // Add more persons
        };
    }
}

public class Person
{
    public int Id { get; set; }
    public string FullName { get; set; }
}
