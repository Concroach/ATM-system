using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Lab5.Infrastructure.DataAccess.Migrations;

[Migration(1)]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider)
    {
        return """
        CREATE TABLE users
        (
            user_id SERIAL PRIMARY KEY,
            name TEXT NOT NULL
        );

        CREATE TABLE accounts
        (
            account_id SERIAL PRIMARY KEY,
            user_id INT NOT NULL REFERENCES users(user_id) ON DELETE CASCADE,
            pincode CHAR(4) NOT NULL,
            balance FLOAT NOT NULL DEFAULT 0.0
                CONSTRAINT balance_positive CHECK (balance >= 0)
        );

        CREATE TABLE operations
        (
            operation_id SERIAL PRIMARY KEY,
            account_id INT NOT NULL REFERENCES accounts(account_id) ON DELETE CASCADE,
            amount_before_operation FLOAT NOT NULL,
            amount_difference FLOAT NOT NULL,
            amount_after_operation FLOAT NOT NULL,
            CONSTRAINT amount_consistency CHECK (amount_before_operation + amount_difference = amount_after_operation)
        );
        """;
    }

    protected override string GetDownSql(IServiceProvider serviceProvider)
    {
        return """
        DROP TABLE operations CASCADE;
        DROP TABLE accounts CASCADE;
        DROP TABLE users CASCADE;
        """;
    }
}