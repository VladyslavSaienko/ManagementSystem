using FluentAssertions;
using ManagementSystem.Application.Dtos.Results.ListStudents;
using ManagementSystem.IntegrationTests.Fixtures;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json;
using TechTalk.SpecFlow;
using ManagementSystem.Infrastructure.EntityFrameworkDataAccess.Entities;

namespace ManagementSystem.IntegrationTests.StepDefinitions;

public class StudentStepDefinitions
{
    private static TestApp _app;
    private static StudentFixture _studentFixture;
    private HttpClient _client;

    private HttpResponseMessage _result;
    private string _payload = string.Empty;

    public StudentStepDefinitions(ScenarioContext scenarioContext)
    {
        _app = scenarioContext.Get<TestApp>();
        _studentFixture = _app.StudentFixture;
    }

    [Given(@"two students are in database")]
    public void GivenTwoStudentsAreInDatabase()
    {
        var contacts = _studentFixture.GenerateTestStudents();
        _studentFixture.SaveStudents(contacts);
    }

    [When(@"the user tries to get all students")]
    public async Task WhenTheUserTriesToGetAllStudents()
    {
        _result = await _client.GetAsync("/api/Students");
    }

    [Then(@"the user retrieves list of all contacts")]
    public async Task ThenTheUserRetrievesListOfAllContacts()
    {
        _result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        var content = await _result.Content.ReadAsStringAsync();
        var users = JsonSerializer.Deserialize<Collection<StudentListItem>>(content, new JsonSerializerOptions(JsonSerializerDefaults.Web));
        users.Should().NotBeEmpty();
        users.Count().Should().BeGreaterThanOrEqualTo(2);
    }

    [Given(@"a student with studentId (.*) is in database")]
    public void GivenAStudentWithStudentIdIsInDatabase(Guid studentId)
    {
        List<StudentEntity> studentEntities = new()
        {
            new()
            {
                Id = studentId,
                NationalIdNumber = "ID12345",
                Name = "John",
                Surname = "Doe",
                Number = "TJ8",
                DateOfBirth = new DateOnly(2004, 4, 15)
            }
        };
        _studentFixture.SaveStudents(studentEntities);
    }

    [When(@"the user tries to create a student with '(.*)' payload")]
    public async Task WhenTheUserTriesToCreateAStudentWithPayload(string fileName)
    {
        _payload = fileName.GetFileContent();
        _result = await _client.PostAsync("/students", new StringContent(_payload, Encoding.UTF8, "application/json"));
    }

    [Then(@"the student creation is successful")]
    public void ThenTheStudentCreationIsSuccessful()
    {
        _result.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
        _app.StudentFixture.GetAllStudents().Should().HaveCount(1);
    }

    [Then(@"the student creation fails")]
    public void ThenTheContactCreationFails()
    {
        _result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        _app.StudentFixture.GetAllStudents().Should().HaveCount(0);
    }

    [When(@"the user tries to delete a student with studentId '(.*)'")]
    public async Task WhenTheUserTriesToDeleteAStudentWithStudentId(Guid studentId)
    {
        _result = await _client.DeleteAsync($"/students/{studentId}");
    }

    [When(@"the user tries to patch a contact with '(.*)' payload and contactId '(.*)'")]
    public async Task WhenTheUserTriesToUpdateAStudentWithPayload(string fileName)
    {
        _payload = fileName.GetFileContent();

        _result = await _client.PatchAsync($"/students", new StringContent(_payload, Encoding.UTF8, "application/json"));
    }

    [Then(@"the call succeeds with HTTP 204 No Content")]
    public void ThenTheCallSucceedsWithHTTP204NoContent()
    {
        _result.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
    }

    [Then(@"the call fails with HTTP 400 Bad Request")]
    public void ThenTheCallFailsWithHTTP400BadRequest()
    {
        _result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
    }

    [Then(@"the call fails with HTTP 404 Not Found")]
    public void ThenTheCallFailsWithHTTP404NotFound()
    {
        _result.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
    }
}
