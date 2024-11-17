-- Получить все оценки видео всеми пользователями. Если оценки нет, то считать, что оценка – 0.

SELECT User.*, Content.Id AS VideoId, COALESCE(Rate.Rating, 0) AS VideoRating
FROM User
CROSS JOIN (SELECT Content.Id
			FROM Content
			RIGHT JOIN Video
			ON Content.Id = Video.ContentId) Content
LEFT JOIN Rate
ON Rate.UserId = User.Id AND Rate.ContentId = Content.Id
ORDER BY User.Id;