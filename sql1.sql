-- Получить контент, отсортированный по убыванию рейтинга (среднее от оценок пользователей. Если оценок нет, то среднее – 0).

SELECT Content.*,
       Article.Text AS Text,
       Gallery.CoverUrl AS CoverUrl,
       Video.Url AS Url, 
       COALESCE((SELECT AVG(Rate.Rating) 
                 FROM Rate 
                 WHERE Rate.ContentId = Content.Id), 0.0) AS AverageRating
FROM Content
LEFT JOIN Article ON Content.Id = Article.ContentId
LEFT JOIN Gallery ON Content.Id = Gallery.ContentId
LEFT JOIN Video ON Content.Id = Video.ContentId
ORDER BY AverageRating DESC;