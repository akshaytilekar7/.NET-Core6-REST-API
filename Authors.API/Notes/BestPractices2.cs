/*

Data Transfer Object (Dto)
    -   all property should be public
    -   object with no behaviour, only states ie, property
Plain POCO classes
    -   Object that doesnt inherit from type define in an external dependancies 


Models
    -   all about transfering data
    -   annoted supprt validation
    -   naming with intenstion reveiling model

Postal's law (robustness)
    -   Be conservative (give less) in what you send, be liberal (accept more) in what you accept, anology for request and response
    
Good api models
    -   Dont return too much data
    -   Dont return too little data (result into more api calls)
    -   Filter and Paging
    -   Well Named
        -   client should understood th resource
        -   dont reveal interal architecure
        -   Reveal intention
            -   Request or cammands
            -   Response or results
    -   Well Factored
            -   dont combine too many concept into one
    -   Well Sized
            -   used many tiny models
            -   provide tools paging and filtering
    -   Stable
            -   property addition is good, removal is bad on DTO
            -   plan for versioning

Antipatterns
    -   No standard names
    -   Database concept leakage
    -   Breaking changes without versioning
    -   No clint control over response Size
    -   No or poor documentation


    


*/ 