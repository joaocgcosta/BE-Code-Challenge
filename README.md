<div class="text-center alert alert-dark">
    <h1 class="display-4">SmartMed - Back End code challenge</h1>
</div>
<div data-purpose="safely-set-inner-html:description:description">
    <p>
    <strong>REST API that allows to: </strong>
    </p>
    <p> <strong>1.</strong> get a list of medications</p>
	<p> <strong>2.</strong> create a new medication</p>
	<p> <strong>3.</strong> delete a medication</p>
	<p>REQUIREMENTS:</p>
	<ul>
		<li><p><strong>Each medication must have a name, a quantity and a creation date:</strong> The quantity must be greater than zero</p></li>
		<li><p>SQL Server database</p></li>
		<li><p>Written in C# using .Net Core</p></li>
		<li><p>Include an example unit test</p></li>
	</ul>
	<p>Future work:</p>
	<ul>
		<li><p>Add resilience strategies</p></li>
		<li><p>Add log strategy</p></li>
	</ul>
<p>Useful commands:</p>
	<ul>
		<li><code>dotnet ef --verbose migrations add CreateInitial --project .\MED.MedicationManagement.Persistence\ --startup-project .\MED.MedicationManagement.Api\</code></li>
		<li><code>dotnet ef --verbose database update --project .\MED.MedicationManagement.Persistence\ --startup-project .\MED.MedicationManagement.Api\</code></li>
	</ul>
</div>
