# FinancialChat

Simple browser-based chat application using .NET.
This application allow several users to talk in a chatroom and also to get stock quotes from an API using a specific command.


Before running the application do the next:

    In Visual Studio, you can use the Package Manager Console to apply pending migrations to the database:

    PM> Update-Database
    Alternatively, you can apply pending migrations from a command prompt at your project directory:

    > dotnet ef database update
    
The application has 3 predefined chatrooms.
