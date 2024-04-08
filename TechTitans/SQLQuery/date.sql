-- connect to the database SongBasicDetails
insert into AuthorDetails values(1, 'Dumiyei')
insert into AuthorDetails values(2, 'Dobu')
insert into AuthorDetails values(3, 'Danilica')
insert into AuthorDetails values(4, 'Iediy')
insert into AuthorDetails values(5, 'Dyanana')
insert into AuthorDetails values(6, 'Boghidy')
insert into AuthorDetails values(7, 'MaineKraft boy')
insert into AuthorDetails values(8, 'Tudie')

insert into UserDemographicsDetails values (1, 'Dumi', 'male', '2002-01-01', 'Romania', 'english', 'motherfucker', 1)
insert into UserDemographicsDetails values (2, 'Andy', 'other', '2003-03-21', 'Nigeria', 'french', 'niggher', 0)

insert into SongBasicDetails VALUES
(1, 'American Boy', 'hip-hop', 'chicago', 7, 'english', 'USA', '-', 'http://plm.com');

insert into Trends VALUES
('hip-hop', 'english', 'USA', 1)

insert into AdDistributionData VALUES
(1, 1, 'hip-hop', 'english', 10, 2023)

insert into UserPlaybackBehaviour VALUES
(1, 1, 1, '2023-12-12 7:25:45')

insert into SongRecommendationDetails VALUES
(1, 15, 4, 1503, 23, 10, 2023)

insert into SongFeatures values
(1, 2)
select * from UserPlaybackBehaviour

--UserDemographicsDetails
--AuthorDetails
--SongBasicDetails
--Trends
--AdDistributionData
--UserPlaybackBehaviour
--SongRecommendationDetails
--SongFeatures