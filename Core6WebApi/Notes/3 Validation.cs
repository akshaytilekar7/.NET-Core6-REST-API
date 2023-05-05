/*

 ASP.NET Core rules are defiend thr
A]
    -   Data Annotation (build in ot custom)
    -   IValidatableObject

 Checking validation rule 
    -   ModelState
        -   dictionary containg state of model and model binding validation
        -   contain colletion of error message for each property
    -   Response body should contain validation message

    -   DataAnnotaion validation on Doamin classes triggers point is based on database provider
        Ex, SqlLiter provider Validation not trigger on SaveChanges() but for SQL server it will give exception
        so best practice is validation should run before hitting database, so add annotation on DTO not on Domain classes
    -   Annotations are check during Model Binding and affect model state dict
    

B]
    validation using IValidatableObject
    public class EmployeeDto : IValidatableObject
        {
            [Required]
            prop string FirstName {get;set;}

            prop string LastName {get;set;}

            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
                {
                    if(FirstName == LastName)
                        yield return new ValidationResult("message" , new [] { "Course" })
                }
        }

       - if firstName is emoty then .NET will not call validate Method as it will stop once we get error
            reason - Validate() is more of corss validation 


TIP
        ControllerMethod(Empoyee obj, string search, string filter)
            - implied search and filter varaible from QueryString, bit what if
        ControllerMethod(Empoyee obj, GridClass grid) // GridClass contain 2 prop search and filter
            - this time will get error GridClass cant maap from QueryString
              so use ControllerMethod(Empoyee obj, [FromQuery] GridClass grid) 
                
*/ 