An API for creating a "Short URL". Use POST to /api/shorten with the payload { "Url" : "your_url_here" }, then recieve a short url that acts as a key. 
Use GET to /api/shorten/{shortUrl}/stats to receive your long URL and stats about the datapoint.
Use PUT to /api/shorten/{shortUrl} to update your url. 
Use DELETE /api/shorten/{shortUrl} to delete your url.
