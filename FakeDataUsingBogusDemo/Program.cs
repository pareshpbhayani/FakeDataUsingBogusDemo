// See https://aka.ms/new-console-template for more information

using Bogus;
using FakeDataUsingBogusDemo;

var userFaker = new Faker<User>()
    .RuleFor(u => u.Id, f => f.IndexFaker + 1)
    .RuleFor(u => u.FirstName, f => f.Name.FirstName())
    .RuleFor(u => u.LastName, f => f.Name.LastName())
    .RuleFor(u => u.Email, f => f.Internet.Email())
    .RuleFor(u => u.DateOfBirth, f => f.Date.Past(20, DateTime.Now.AddYears(-18)));

var fakeUsers = userFaker.Generate(10);

foreach (var user in fakeUsers)
{
    Console.WriteLine($"{user.Id}: {user.FirstName} {user.LastName}, Email: {user.Email}, DOB: {user.DateOfBirth.ToShortDateString()}");
}