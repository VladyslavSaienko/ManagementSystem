Feature: AddStudent

Can add students

Scenario: User can add a new student
	When the user tries to add a student with 'NewStudent.json' payload 
	Then the student creation is successful 
