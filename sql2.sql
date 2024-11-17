-- Получить пользователей, отсортированных по убыванию рейтинга (рейтинг пользователя – средний рейтинг созданного им контента).

SELECT User.*, COALESCE(AVG(ContentRating), 0.0) AS UserRating
FROM User
LEFT JOIN (SELECT CreatorId,
				  (SELECT AVG(Rate.Rating) 
				   FROM Rate 
				   WHERE Rate.ContentId = Content.CreatorId) AS ContentRating
		   FROM Content)
ON CreatorId = User.Id
GROUP BY User.Id
ORDER BY UserRating DESC;