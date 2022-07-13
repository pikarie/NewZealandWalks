USE [NZTrailsDb]

SELECT * FROM [dbo].[Regions]
SELECT * FROM [dbo].[Trails]
SELECT * FROM [dbo].[Reviews]

INSERT INTO Regions (Id, Code, Name, Area, Latitude, Longitude, Population) VALUES 
	('b950ddf5-e9ad-47ff-9d2a-57259014fae6', 'NRTHL', 'Northland Region', 13789, -35.3708304, 172.5717825, 194600),
	('907f54ba-2142-4719-aef9-6230c23bd7de', 'AUCK', 'Auckland Region', 4894, -36.5253207, 173.7785704, 1718982),
	('79e9872d-5a2f-413e-ac36-511036ccd3d4', 'WAIK', 'Waikato Region', 8970, -37.5144584, 174.5405128, 496700),
	('68c2ab66-c5eb-40b6-81e0-954456d06bba', 'BAYP', 'Bay Of Plenty Region', 12230, -37.5328259, 175.7642701, 345400);

INSERT INTO Trails (Id, Name, Length, TimeInSeconds, TrailDifficulty, RegionId) VALUES
	('43ef2fce-e44f-40a9-a83a-b3167564749b', 'Waiotemarama Loop Track', 1.5, 4980, 3, 'b950ddf5-e9ad-47ff-9d2a-57259014fae6'),
	('b38d0b27-f823-4c98-8db5-1d8f4be08cc6', 'Mt Eden Volcano Walk', 2, 2640, 1, '907f54ba-2142-4719-aef9-6230c23bd7de'),
	('376fb74e-cc57-440f-ac51-207f3d55a647', 'One Tree Hill Walk', 3.5, 3300, 1, '79e9872d-5a2f-413e-ac36-511036ccd3d4'),
	('792bbab2-7165-4b91-b277-1c1f3878daed', 'Lonely Bay', 1.2, 3360, 2, '79e9872d-5a2f-413e-ac36-511036ccd3d4'),
	('dd73b700-c4cd-4794-b981-c2bdc88f2bc1', 'Mt Te Aroha To Wharawhara Track Walk', 32, 3420, 2, '68c2ab66-c5eb-40b6-81e0-954456d06bba'),
	('24209e64-0703-4bea-a1de-fdffae87d8c0', 'Rainbow Mountain Reserve Walk', 3.5, 3480, 3, '68c2ab66-c5eb-40b6-81e0-954456d06bba');

INSERT INTO Reviews (Id, Username, Email, Rating, LikedComment, DislikedComment, TrailId) VALUES
	('0c63f1b6-cd5e-4114-9596-92fbff0b206b', 'John', 'john@gmail.com', 72, 'Beautiful scenary ♥', NULL, '43ef2fce-e44f-40a9-a83a-b3167564749b'),
	('11512487-f54b-4a63-873c-555b4984cf8a', 'Max', 'max@gmail.com', 68, NULL, 'A lot of trash on this trail :(.','b38d0b27-f823-4c98-8db5-1d8f4be08cc6'),
	('ec986594-b42b-43a1-a5bd-958e573b9507', 'Camellia', 'camellia123@gmail.com', 95, 'The optional path behind the waterfall was so much fun!', NULL,'24209e64-0703-4bea-a1de-fdffae87d8c0'),
	('c8baa28e-2b9e-49f5-a96b-eeb5d139efca', 'Egbert Winterstorm', NULL, 52, 'A little bit too hard for my taste.', NULL,'24209e64-0703-4bea-a1de-fdffae87d8c0');

--Seed for users and roles, video 101/101

SELECT * FROM [dbo].[Users]
SELECT * FROM [dbo].[Roles]
SELECT * FROM [dbo].[Users_Roles]

--Insert Users
INSERT INTO Users (Id, Username, Email, Password, FirstName, LastName) VALUES
	('aaaaaaaa-b9e9-4e1b-b89c-362c14c24ff1', 'username1', 'username1@user.com', 'password1', 'FirstNameUser1', 'LastNameUser1'),
	('bbbbbbbb-b9e9-4e1b-b89c-362c14c24ff1', 'username2', 'username2@user.com', 'password2', 'FirstNameUser2', 'LastNameUser2');

--Insert Roles
INSERT INTO Roles (Id, Name) VALUES
	('663EC6C3-E369-47E6-87C5-1CCB8B7DFA33', 'reader'),
	('B7717016-1BDF-475D-9916-EB8BB22769D3', 'writer');


--Insert Users_Roles
INSERT INTO Users_Roles (Id, UserId, RoleId) VALUES
	('7c2d51cb-c878-49a6-8392-f5ee28bd3602', 'aaaaaaaa-b9e9-4e1b-b89c-362c14c24ff1', '663EC6C3-E369-47E6-87C5-1CCB8B7DFA33'),
	('13cbebb1-5f80-43c5-a7af-292e05e62956', 'bbbbbbbb-b9e9-4e1b-b89c-362c14c24ff1', '663EC6C3-E369-47E6-87C5-1CCB8B7DFA33'),
	('c1d8925c-aa2f-404e-af23-e5a6f1774c8f', 'bbbbbbbb-b9e9-4e1b-b89c-362c14c24ff1', 'B7717016-1BDF-475D-9916-EB8BB22769D3');


