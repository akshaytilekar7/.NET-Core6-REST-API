/*

launchSetting
	-	setup the env for local machine development (only local)
	-	has profiles
		-	command name : Project 
			-	uses kestral web server, see console window which act as host
			-	inline with cross platform
		-	IIS Express (IIS as web server)
		
	- run using CLI
		-	cross platform tool chain for devloping, running, and publishing .net app
		-	command -> dotnet new/sln/test/build/clean
		
- no main method and namespace
	-	top level featured statement
	
middleware
	-	components that are added into app pipeline to handle req and response (auth, dignostoc)

Routing
	-	matches req URI to an action on a controller
	-	app.UseRouting()  
		-	mark the position in midddleware pipeline where routing decision is made
	-	app.UseEndpoints()
		-	mark the position in midddleware pipeline where selected enpoing is executed
		so this allowed us to inject midddleware that runs between selecting endpoint and executing endpoints
		Example - 
			app.UseRouting()
			app.UseAuthorization()
			app.UseEndpoints()
			
	- map endpoints by 2 way
		-	Conventions based
		-	attribute based (enpoint.MapControllers())
		
Content Negotiation
	-	process of selecting best representation for given response when there are multiple representation avaialble
	-	Formatters
		Output Formatters - media types are pass via 'Accept headers' of the request (response format)
		Input Formatters  - media types are pass via 'Content Type headers' of the request (response format)
	
	- what if client demand xml but server dont support that op format
		-	app would return resp with default op format, but its bad coz clitnt want xml and we gave json
			fix is
			builder.service.AddController(options =>
			option.ReturnHttpNotAccetable = true)
			
			to add xml format
			builder.service.AddController(options =>
			option.ReturnHttpNotAccetable = true).AddXamlDataContract...()
			
		- To make default formatters
			builder.service.AddController(options =>
			  options.InputFomatters()  // add default 
				or 
			  options.outFomatters()  // add default 
			option.ReturnHttpNotAccetable = true).AddXamlDataContract...()
			
		- TBD
			-   fromBody
			-	fromRoute
			- 	Oaritakky Update PATCH VIMP (want to update big object)
			
		
IOC
	-	delegates function of selecting concreate implmentation type for class dependancies to an external component
		this is achive by DI
	
	-	see what query is executed in DB by EF 
		-	Looging section > LogLevel > Microsoft.EntityFrameworkCore.Database.Command : "Information"
		
Deffered Execution
	-	occures sometimes after the query is executed
		executed when we uses	
			-	foreach / ToList / ToArray / ToDictionary
			-	Singleton qurires - Count / Avreage 

API Versioning
	-	

*/