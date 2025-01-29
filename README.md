[English Version](README[en].md)
# Банкомат

## Описание
Реализована система банкомата с использованием **ASP.NET Core**, **Entity Framework** и базы данных **PostgreSQL**.

## Функциональность
- Создание счета
- Просмотр баланса счета
- Снятие денег со счета
- Пополнение счета
- Просмотр истории операций

## Архитектура
Используется гексагональная архитектура
- **Application** – Async/Sync services (business logic), ports, entities
- **Infrastructure** – database, repositories, migrations
- **Presentation** – web API and console representations

## Технологии
- **ASP.NET Core Web API**
- **Entity Framework Core** 
- **PostgreSQL**
- **xUnit, Moq**

## Запуск проекта
1. Установите зависимости:
   ```sh
   dotnet restore
   ```
2. Примените миграции базы данных:
   ```sh
   dotnet ef database update
   ```
3. Запустите приложение:
   ```sh
   dotnet run
   ```

## Тестирование
Написаны unit-тесты для проверки бизнес-логики с использованием моков

Запуск тестов:
```sh
dotnet test
```
