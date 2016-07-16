USE [UCL]
GO
SET IDENTITY_INSERT [UCL].[Team] ON 

IF NOT EXISTS (SELECT 1 FROM [UCL].[Team])
BEGIN

INSERT [UCL].[Team] ([TeamId], [Name], [Country], [FormationYear], [Eliminated]) VALUES (1, N'Real Madrid', N'Spain', 1902, 0)
INSERT [UCL].[Team] ([TeamId], [Name], [Country], [FormationYear], [Eliminated]) VALUES (2, N'Barcelona', N'Spain', 1899, 1)
INSERT [UCL].[Team] ([TeamId], [Name], [Country], [FormationYear], [Eliminated]) VALUES (3, N'Bayern Munchen', N'Germany', 1900, 0)
INSERT [UCL].[Team] ([TeamId], [Name], [Country], [FormationYear], [Eliminated]) VALUES (4, N'Manchester United', N'England', 1878, 1)
INSERT [UCL].[Team] ([TeamId], [Name], [Country], [FormationYear], [Eliminated]) VALUES (5, N'Arsenal', N'England', 1886, 0)
INSERT [UCL].[Team] ([TeamId], [Name], [Country], [FormationYear], [Eliminated]) VALUES (6, N'Chelsea', N'England', 1905, 1)
INSERT [UCL].[Team] ([TeamId], [Name], [Country], [FormationYear], [Eliminated]) VALUES (7, N'Liverpool', N'England', 1892, 0)
INSERT [UCL].[Team] ([TeamId], [Name], [Country], [FormationYear], [Eliminated]) VALUES (8, N'Manchester City', N'England', 1880, 0)
INSERT [UCL].[Team] ([TeamId], [Name], [Country], [FormationYear], [Eliminated]) VALUES (9, N'Atletico Madrid', N'Spain', 1903, 0)
INSERT [UCL].[Team] ([TeamId], [Name], [Country], [FormationYear], [Eliminated]) VALUES (10, N'Borussia Dortmund', N'Germany', 1909, 0)

END
SET IDENTITY_INSERT [UCL].[Team] OFF
GO



SET IDENTITY_INSERT [UCL].[Player] ON 
GO

IF NOT EXISTS (SELECT 1 FROM [UCL].[Player])
BEGIN
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (1, N'Cristiano', N'Ronaldo', CAST(N'1985-02-05 00:00:00.000' AS DateTime), N'Portugal', CAST(17000000.00 AS Decimal(18, 2)), 2008, 1, 1, NULL, 1)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (2, N'Andres', N'Iniesta', CAST(N'1984-05-11 00:00:00.000' AS DateTime), N'Spain', CAST(5000000.00 AS Decimal(18, 2)), 2002, 1, 2, NULL, 3)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (3, N'Gareth', N'Bale', CAST(N'1987-07-16 00:00:00.000' AS DateTime), N'Wales', CAST(15000000.00 AS Decimal(18, 2)), 2013, 1, 1, 1, 2)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (4, N'Philipp', N'Lahm', CAST(N'1983-11-11 00:00:00.000' AS DateTime), N'Germany', CAST(8320000.00 AS Decimal(18, 2)), 2002, 1, 3, NULL, 3)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (5, N'Wayne', N'Rooney', CAST(N'1985-11-24 00:00:00.000' AS DateTime), N'England', CAST(13000000.00 AS Decimal(18, 2)), 2004, 1, 4, NULL, 1)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (6, N'John', N'Terry', CAST(N'1980-12-07 00:00:00.000' AS DateTime), N'England', CAST(6760000.00 AS Decimal(18, 2)), 1998, 1, 6, NULL, 3)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (7, N'Neymar', N'Santos', CAST(N'1992-01-07 00:00:00.000' AS DateTime), N'Brazil', CAST(25000000.00 AS Decimal(18, 2)), 2012, 1, 2, 2, 1)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (8, N'Olivier', N'Giroud', CAST(N'1986-09-16 00:00:00.000' AS DateTime), N'France', CAST(3120000.00 AS Decimal(18, 2)), 2015, 1, 5, NULL, 1)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (9, N'Marco', N'Reus', CAST(N'1989-05-21 00:00:00.000' AS DateTime), N'Germany', CAST(4000000.00 AS Decimal(18, 2)), 2013, 1, 10, NULL, 2)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (10, N'Gabi', N'Arenas', CAST(N'1983-07-10 00:00:00.000' AS DateTime), N'Spain', CAST(8000000.00 AS Decimal(18, 2)), 2011, 1, 9, NULL, 2)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (11, N'Vincent', N'Kompany', CAST(N'1986-04-10 00:00:00.000' AS DateTime), N'Belgium', CAST(1040000.00 AS Decimal(18, 2)), 2008, 1, 8, NULL, 3)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (12, N'Sergio', N'Aguero', CAST(N'1988-06-02 00:00:00.000' AS DateTime), N'Argentina', CAST(12000000.00 AS Decimal(18, 2)), 2013, 1, 8, 11, 1)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (13, N'Yaya', N'Toure', CAST(N'1983-05-13 00:00:00.000' AS DateTime), N'Ivory Coast', CAST(20000000.00 AS Decimal(18, 2)), 2012, 1, 8, 11, 2)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (14, N'Joe', N'Hart', CAST(N'1983-04-19 00:00:00.000' AS DateTime), N'England', CAST(4680000.00 AS Decimal(18, 2)), 2013, 1, 8, 11, 4)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (15, N'James', N'Rodriguez', CAST(N'1991-07-12 00:00:00.000' AS DateTime), N'Columbia', CAST(1000000.00 AS Decimal(18, 2)), 2014, 1, 1, 1, 2)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (16, N'Marcelo', N'Vieira', CAST(N'1988-05-12 00:00:00.000' AS DateTime), N'Brazilia', CAST(7000000.00 AS Decimal(18, 2)), 2012, 1, 1, 1, 3)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (17, N'Toni', N'Kroos', CAST(N'1990-01-04 00:00:00.000' AS DateTime), N'Germany', CAST(12000000.00 AS Decimal(18, 2)), 2014, 1, 1, 1, 3)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (18, N'Lionel', N'Messi', CAST(N'1987-06-24 00:00:00.000' AS DateTime), N'Argentina', CAST(36000000.00 AS Decimal(18, 2)), 2007, 1, 2, 2, 1)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (19, N'Gerard', N'Pique', CAST(N'1987-02-02 00:00:00.000' AS DateTime), N'Spain', CAST(5800000.00 AS Decimal(18, 2)), 2008, 1, 2, 2, 3)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (20, N'Luis', N'Suarez', CAST(N'1987-01-24 00:00:00.000' AS DateTime), N'Uruguay', CAST(1040000.00 AS Decimal(18, 2)), 2014, 1, 2, 2, 1)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (21, N'Frank', N'Ribery', CAST(N'1983-04-07 00:00:00.000' AS DateTime), N'France', CAST(8320000.00 AS Decimal(18, 2)), 2007, 1, 3, 4, 1)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (22, N'Robert', N'Lewandowski', CAST(N'1988-08-21 00:00:00.000' AS DateTime), N'Poland', CAST(1000000.00 AS Decimal(18, 2)), 2014, 1, 3, 4, 1)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (23, N'Mario', N'Gotze', CAST(N'1992-06-03 00:00:00.000' AS DateTime), N'Germany', CAST(7000000.00 AS Decimal(18, 2)), 2013, 1, 3, 4, 2)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (24, N'Arjen', N'Robben', CAST(N'1984-01-23 00:00:00.000' AS DateTime), N'Netherlands', CAST(9800000.00 AS Decimal(18, 2)), 2009, 1, 3, 4, 2)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (25, N'Manuel', N'Neuer', CAST(N'1986-03-23 00:00:00.000' AS DateTime), N'Germany', CAST(7620000.00 AS Decimal(18, 2)), 2011, 1, 3, 4, 4)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (26, N'Zlatan', N'Ibrahimovic', CAST(N'1981-11-03 00:00:00.000' AS DateTime), N'Sweden', CAST(11440000.00 AS Decimal(18, 2)), 2015, 1, 4, 5, 1)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (27, N'Juan', N'Mata', CAST(N'1988-04-28 00:00:00.000' AS DateTime), N'Spain', CAST(8500000.00 AS Decimal(18, 2)), 2014, 1, 4, 5, 2)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (28, N'David', N'De Gea', CAST(N'1990-11-08 00:00:00.000' AS DateTime), N'Spain', CAST(3900000.00 AS Decimal(18, 2)), 2013, 1, 4, 5, 4)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (29, N'Ashley', N'Young', CAST(N'1985-07-09 00:00:00.000' AS DateTime), N'England', CAST(6240000.00 AS Decimal(18, 2)), 2011, 1, 4, 5, 1)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (30, N'Bastian', N'Schweinsteiger', CAST(N'1984-08-01 00:00:00.000' AS DateTime), N'Germany', CAST(1430000.00 AS Decimal(18, 2)), 2015, 1, 4, 5, 2)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (31, N'Eden', N'Hazard', CAST(N'1991-01-07 00:00:00.000' AS DateTime), N'Belgium', CAST(5500000.00 AS Decimal(18, 2)), 2012, 1, 6, 6, 1)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (32, N'Oscar', N'Santos', CAST(N'1991-10-09 00:00:00.000' AS DateTime), N'Brazil', CAST(8000000.00 AS Decimal(18, 2)), 2012, 1, 6, 6, 2)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (33, N'Cesc', N'Fabregas', CAST(N'1974-03-04 00:00:00.000' AS DateTime), N'Spain', CAST(6000000.00 AS Decimal(18, 2)), 2014, 1, 6, 6, 2)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (34, N'Diego', N'Costa', CAST(N'1988-11-08 00:00:00.000' AS DateTime), N'Brazil', CAST(7800000.00 AS Decimal(18, 2)), 2014, 1, 6, 6, 1)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (35, N'Thibaut', N'Courtois', CAST(N'1992-05-11 00:00:00.000' AS DateTime), N'France', CAST(3000000.00 AS Decimal(18, 2)), 2014, 1, 6, 6, 4)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (36, N'Gary', N'Cahill', CAST(N'1985-12-19 00:00:00.000' AS DateTime), N'England', CAST(4160000.00 AS Decimal(18, 2)), 2012, 1, 6, 6, 3)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (37, N'Fernando', N'Torres', CAST(N'1984-03-20 00:00:00.000' AS DateTime), N'Spain', CAST(4000000.00 AS Decimal(18, 2)), 2014, 1, 9, 10, 1)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (38, N'Antoine', N'Griezmann', CAST(N'1991-03-21 00:00:00.000' AS DateTime), N'France', CAST(7500000.00 AS Decimal(18, 2)), 2014, 1, 9, 10, 1)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (39, N'Diego', N'Godin', CAST(N'1986-02-14 00:00:00.000' AS DateTime), N'Uruguay', CAST(6800000.00 AS Decimal(18, 2)), 2010, 1, 9, 10, 3)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (40, N'Koke', N'Merrodio', CAST(N'1992-01-24 00:00:00.000' AS DateTime), N'Spain', CAST(1000000.00 AS Decimal(18, 2)), 2009, 1, 9, 10, 2)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (41, N'Karim', N'Benzema', CAST(N'1987-12-19 00:00:00.000' AS DateTime), N'France', CAST(8000000.00 AS Decimal(18, 2)), 2012, 1, 1, 1, 1)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (42, N'Raphael', N'Varane', CAST(N'1993-04-23 00:00:00.000' AS DateTime), N'France', CAST(1300000.00 AS Decimal(18, 2)), 2013, 1, 1, 1, 3)
INSERT [UCL].[Player] ([PlayerId], [FirstName], [LastName], [DateOfBirth], [Nationality], [Salary], [StartYear], [Available], [TeamId], [CaptainId], [PositionId]) VALUES (43, N'Pepe', N'Ferreira', CAST(N'1983-02-26 00:00:00.000' AS DateTime), N'Brazil', CAST(5720000.00 AS Decimal(18, 2)), 2013, 1, 1, 1, 3)

END
SET IDENTITY_INSERT [UCL].[Player] OFF
GO



SET IDENTITY_INSERT [UCL].[Stadium] ON 
GO
IF NOT EXISTS (SELECT 1 FROM [UCL].[Stadium])
BEGIN
INSERT [UCL].[Stadium] ([StadiumId], [Name], [City], [Capacity], [TeamId]) VALUES (1, N'Bernabeu',N'Madrid',81000,1)
INSERT [UCL].[Stadium] ([StadiumId], [Name], [City], [Capacity], [TeamId]) VALUES (2, N'Camp Nou',N'Barcelona',100000,2)
INSERT [UCL].[Stadium] ([StadiumId], [Name], [City], [Capacity], [TeamId]) VALUES (3, N'Allianz Arena',N'Munchen',75000,3)
INSERT [UCL].[Stadium] ([StadiumId], [Name], [City], [Capacity], [TeamId]) VALUES (4, N'Old Trafford',N'Manchester',75000,4)
INSERT [UCL].[Stadium] ([StadiumId], [Name], [City], [Capacity], [TeamId]) VALUES (5, N'Emirates',N'London',60300,5)
INSERT [UCL].[Stadium] ([StadiumId], [Name], [City], [Capacity], [TeamId]) VALUES (6, N'Stamford Bridge',N'London',41663,6)
INSERT [UCL].[Stadium] ([StadiumId], [Name], [City], [Capacity], [TeamId]) VALUES (7, N'Anfield',N'Liverpool',44742,7)
INSERT [UCL].[Stadium] ([StadiumId], [Name], [City], [Capacity], [TeamId]) VALUES (8, N'Etihad',N'Manchester',60000,8)
INSERT [UCL].[Stadium] ([StadiumId], [Name], [City], [Capacity], [TeamId]) VALUES (9, N'Vicente Calderon',N'Madrid',55000,9)
INSERT [UCL].[Stadium] ([StadiumId], [Name], [City], [Capacity], [TeamId]) VALUES (10, N'Westfalenstadion',N'Dortmund',81400,10)
END
SET IDENTITY_INSERT [UCL].[Stadium] OFF
GO

SET IDENTITY_INSERT [UCL].[Coach] ON 
GO
IF NOT EXISTS (SELECT 1 FROM [UCL].[Coach])
BEGIN
INSERT [UCL].[Coach] ([CoachId], [FirstName], [LastName], [StartYear], [Type], [TeamId]) VALUES (1, N'Zinedine',N'Zidane',2015,1,1)
INSERT [UCL].[Coach] ([CoachId], [FirstName], [LastName], [StartYear], [Type], [TeamId]) VALUES (2, N'Luis',N'Enrique',2014,1,2)
INSERT [UCL].[Coach] ([CoachId], [FirstName], [LastName], [StartYear], [Type], [TeamId]) VALUES (3, N'Carlo',N'Ancelotti',2015,1,3)
INSERT [UCL].[Coach] ([CoachId], [FirstName], [LastName], [StartYear], [Type], [TeamId]) VALUES (4, N'Jose',N'Mourinho',2016,1,4)
INSERT [UCL].[Coach] ([CoachId], [FirstName], [LastName], [StartYear], [Type], [TeamId]) VALUES (5, N'Arsene',N'Wenger',1996,1,5)
INSERT [UCL].[Coach] ([CoachId], [FirstName], [LastName], [StartYear], [Type], [TeamId]) VALUES (6, N'Antonio',N'Conte',2016,1,6)
INSERT [UCL].[Coach] ([CoachId], [FirstName], [LastName], [StartYear], [Type], [TeamId]) VALUES (7, N'Jurgen',N'Klopp',2015,1,7)
INSERT [UCL].[Coach] ([CoachId], [FirstName], [LastName], [StartYear], [Type], [TeamId]) VALUES (8, N'Josep',N'Guardiola',2016,1,8)
INSERT [UCL].[Coach] ([CoachId], [FirstName], [LastName], [StartYear], [Type], [TeamId]) VALUES (9, N'Diego',N'Simeone',2011,1,9)
INSERT [UCL].[Coach] ([CoachId], [FirstName], [LastName], [StartYear], [Type], [TeamId]) VALUES (10, N'Thomas',N'Tuchel',2016,1,10)

END
SET IDENTITY_INSERT [UCL].[Coach] OFF
GO

SET IDENTITY_INSERT [UCL].[Match] ON 
GO
BEGIN
INSERT [UCL].[Match] ([MatchId],[Date],[HostScore],[GuestScore],[Type],[EndsWithPenalty],[HostId],[GuestId]) VALUES (1,CAST(N'2016-06-10 00:00:00.000' AS DateTime), 2, 1, 1, 0, 1, 2)
INSERT [UCL].[Match] ([MatchId],[Date],[HostScore],[GuestScore],[Type],[EndsWithPenalty],[HostId],[GuestId]) VALUES (2,CAST(N'2016-06-11 00:00:00.000' AS DateTime), 2, 3, 1, 0, 4, 3)
INSERT [UCL].[Match] ([MatchId],[Date],[HostScore],[GuestScore],[Type],[EndsWithPenalty],[HostId],[GuestId]) VALUES (3,CAST(N'2016-06-12 00:00:00.000' AS DateTime), 1, 1, 2, 0, 2, 1)
INSERT [UCL].[Match] ([MatchId],[Date],[HostScore],[GuestScore],[Type],[EndsWithPenalty],[HostId],[GuestId]) VALUES (4,CAST(N'2016-06-13 00:00:00.000' AS DateTime), 0, 3, 1, 0, 6, 9)
INSERT [UCL].[Match] ([MatchId],[Date],[HostScore],[GuestScore],[Type],[EndsWithPenalty],[HostId],[GuestId]) VALUES (5,CAST(N'2016-06-14 00:00:00.000' AS DateTime), 5, 3, 2, 0, 3, 4)
INSERT [UCL].[Match] ([MatchId],[Date],[HostScore],[GuestScore],[Type],[EndsWithPenalty],[HostId],[GuestId]) VALUES (6,CAST(N'2016-06-15 00:00:00.000' AS DateTime), 2, 1, 2, 0, 9, 6)


END
SET IDENTITY_INSERT [UCL].[Match] OFF
GO


SET IDENTITY_INSERT [UCL].[MatchPlayer] ON 
GO
BEGIN
INSERT [UCL].[MatchPlayer] ([MatchPlayerId],[MinutesPlayed],[Rating],[Goals],[RedCards],[YellowCards],[PlayerId],[MatchId]) VALUES (1,90, 92, 2, 0, 1, 1, 1)
INSERT [UCL].[MatchPlayer] ([MatchPlayerId],[MinutesPlayed],[Rating],[Goals],[RedCards],[YellowCards],[PlayerId],[MatchId]) VALUES (2,90, 92, 1, 0, 0, 18, 1)
INSERT [UCL].[MatchPlayer] ([MatchPlayerId],[MinutesPlayed],[Rating],[Goals],[RedCards],[YellowCards],[PlayerId],[MatchId]) VALUES (3,86, 95, 3, 0, 1, 22, 2)
INSERT [UCL].[MatchPlayer] ([MatchPlayerId],[MinutesPlayed],[Rating],[Goals],[RedCards],[YellowCards],[PlayerId],[MatchId]) VALUES (4,90, 84, 2, 0, 1, 26, 2)
INSERT [UCL].[MatchPlayer] ([MatchPlayerId],[MinutesPlayed],[Rating],[Goals],[RedCards],[YellowCards],[PlayerId],[MatchId]) VALUES (5,82, 79, 0, 0, 1, 30, 2)
INSERT [UCL].[MatchPlayer] ([MatchPlayerId],[MinutesPlayed],[Rating],[Goals],[RedCards],[YellowCards],[PlayerId],[MatchId]) VALUES (6,90, 93, 0, 0, 0, 4, 2)
INSERT [UCL].[MatchPlayer] ([MatchPlayerId],[MinutesPlayed],[Rating],[Goals],[RedCards],[YellowCards],[PlayerId],[MatchId]) VALUES (7,90, 96, 0, 0, 1, 10, 4)
INSERT [UCL].[MatchPlayer] ([MatchPlayerId],[MinutesPlayed],[Rating],[Goals],[RedCards],[YellowCards],[PlayerId],[MatchId]) VALUES (8,55, 68, 0, 1, 0, 33, 4)
INSERT [UCL].[MatchPlayer] ([MatchPlayerId],[MinutesPlayed],[Rating],[Goals],[RedCards],[YellowCards],[PlayerId],[MatchId]) VALUES (9,90, 92, 1, 0, 0, 38, 4)
INSERT [UCL].[MatchPlayer] ([MatchPlayerId],[MinutesPlayed],[Rating],[Goals],[RedCards],[YellowCards],[PlayerId],[MatchId]) VALUES (10,80, 94, 2, 0, 1, 37, 4)
END
SET IDENTITY_INSERT [UCL].[MatchPlayer] OFF
GO

