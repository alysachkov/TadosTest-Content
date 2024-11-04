Заготовка для выполнения тестового задания
==========================================

Предметная область
------------------

1. Страна – обладает названием. Не может быть больше одной страны с одинаковым именем.
2. Город – входит в одну страну. Обладает названием. Не может быть больше одного города с одинаковым именем в одной стране.
3. Пользователь – обладает логином (почтой), входит в город. Не может быть двух пользователей с одним логином.
4. Контент – обладает названием и категорией, создается пользователем.
    1. Статья – контент, у которого есть текст (возможно, очень большой).
    2. Видео – контент, у которого есть ссылка на видео (например, ссылка на youtube).
    3. Галерея – контент, у которого есть ссылки на оригинальные изображения. У галереи есть обложка – тоже изображение.
    4.	Пользователь может оценивать контент. Один пользователь может оценить контент один раз. Оценка – целое число в диапазоне от 1 до 5.
6.	Со временем могут появляться новые категории контента.


Задача
------

Реализовать веб-сервис, при этом соблюсти следующие требования:

1. Использовать подход, который был рассмотрен в рамках практикума:
    1. Домен и доменные сервисы.
    2. CQS.
    3. ORM (очень предпочтительно, чтоб это был NHibernate).
    4. Обработка запросов.
2. Для полученной в ходе разработки схемы базы данных написать запросы с использованием SQL (не использовать ORM!):
    1. Получить контент, отсортированный по убыванию рейтинга (среднее от оценок пользователей. Если оценок нет, то среднее – 0).
    2. Получить пользователей, отсортированных по убыванию рейтинга (рейтинг пользователя – средний рейтинг созданного им контента).
    3. Получить все оценки видео всеми пользователями. Если оценки нет, то считать, что оценка – 0.

Можно (и нужно) в качестве референса использовать код, [реализованный](https://github.com/TadosCompany/TadosDevSchool-Pets) по итогам [практикума](https://www.youtube.com/playlist?list=PLbL3X-OQd8EJLEszyaYbDqxc9FFYRjqz2). Не возбраняется использовать реализации с точностью до копипасты. Следует учитывать, что после реализации и ревью кода будет очное общение по реализованной кодовой базе (желательно понимать, почему реализованные вами вещи реализованы именно тем способом, которым они реализованы, какие у реализации плюсы и минусы).

В качестве СУБД можно использовать любую РСУБД, но учитывайте, что ваш код будут запускать, а используемой вами СУБД может не быть у проверяющих. Если есть сомнения – лучше уточните.

Работа с проектом
-----------------

Для запуска проекта требуется [.NET SDK 5.0](https://dotnet.microsoft.com/download/dotnet/5.0).
После клонирования или скачивания репозитория в папке проекта достаточно выполнить:

```dotnet run```

Схема API доступна по адресу [http://localhost:5000/swagger](http://localhost:5000/swagger).

Полезные ссылки
---------------

1. [Записи практикума на YouTube](https://www.youtube.com/playlist?list=PLbL3X-OQd8EJLEszyaYbDqxc9FFYRjqz2)
2. [Список рекомендуемых книг и ссылок по бэкенду](https://tados.ru/blog/dotnet-backend-books)
3. [Анонсы митапов Tados в ВК](https://vk.com/tados_life)
4. Задать вопрос о вакансиях/команде/тестовом можно нашему HR Маше: в [ВК](https://vk.com/masha.tados), [Телеграме](https://t.me/MashaTretyakova), на [почту](mailto:tretyakova@tados.ru).