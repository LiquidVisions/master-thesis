var forecast = app.NewVersionedApi();

// GET /weatherforecast?api-version=1.0
forecast.MapGet( "/weatherforecast", () =>
         {
             return Enumerable.Range( 1, 5 ).Select( index =>
                 new WeatherForecast
                 (
                     DateTime.Now.AddDays( index ),
                     Random.Shared.Next( -20, 55 ),
                     summaries[Random.Shared.Next( summaries.Length )]
                 ) );
         } )
        .HasApiVersion( 1.0 );

// GET /weatherforecast?api-version=2.0
var v2 = forecast.MapGroup( "/weatherforecast" )
                 .HasApiVersion( 2.0 );