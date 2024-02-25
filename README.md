**Проект MarketPlaceApp**
Это пример проекта веб-приложения MarketPlaceApp, созданного с помощью ASP.NET Core и базы данных Microsoft SQL Server.

**Установка и настройка**
Для запуска проекта необходимо выполнить следующие шаги:

* Скачайте исходный код проекта из репозитория GitLab
* Откройте файл MarketPlaceApp.sln в Visual Studio или другой среде разработки
* Откройте файл appsettings.json и укажите строку подключения к вашей базе данных. 
Пример строки подключения:
"ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB; Database=MarketPlaceDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
* Запустите миграции, чтобы создать таблицы базы данных. Откройте консоль диспетчера пакетов для MarketPlace.Data.Persistent и выполните следующие команды:
Update-Database

**Имеющиеся данные в БД:**
* Пользователи: 
* * Админ: логин - admin, пароль - admin
* * Пользователь: логин - customer, пароль - customer
* Категории: 
* * Cars
* * Food
* * Technologies
* Продукты: 
* * Volkswagen Polo
* * BMW M3
* * Apple
* * Potato
* * Carrot