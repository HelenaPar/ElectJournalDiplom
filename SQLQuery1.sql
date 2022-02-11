USE [Journal]
GO
SET IDENTITY_INSERT [dbo].[Groups] ON 
GO
INSERT [dbo].[Groups] ([Id], [Name]) VALUES (1, N'28тп')
GO
INSERT [dbo].[Groups] ([Id], [Name]) VALUES (2, N'29тп')
GO
INSERT [dbo].[Groups] ([Id], [Name]) VALUES (3, N'312эвм')
GO
INSERT [dbo].[Groups] ([Id], [Name]) VALUES (4, N'313эвм')
GO
INSERT [dbo].[Groups] ([Id], [Name]) VALUES (5, N'314эвм')
GO
SET IDENTITY_INSERT [dbo].[Groups] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 
GO
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (1, N'admin')
GO
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (2, N'teacher')
GO
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (3, N'student')
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [GroupId], [RoleId], [Login], [Password], [Name], [LastName], [MiddleName], [Salt]) VALUES (1, NULL, 2, N'Mark21', N'7aLGj8p5My2PpLwWtm75IHZKoR0wJB1sQEYKh/XxmVN3kPp7z4s3oCkpYlvvYlzvbv5NrAYfwhKUuf70hz7PJ8Ttu9711yox5Y0ouvFQ5ZBdBLgx3Elh9AyjmN1QKY8U', N'Евгений', N'Никифоров', N'Святославович', N'P85iHaWDtPxq2AWjzZR0yfQwBGxDBJ6O28/HgNULFQNN+jhw/MEObwKBq/KUF5hdTVhVMa0gZ7D5ZelYTtA9b9X6NXVU03fPvSy38q5uYRkjrDK0/gJ1x/ff0fhG+X0v')
GO
INSERT [dbo].[Users] ([Id], [GroupId], [RoleId], [Login], [Password], [Name], [LastName], [MiddleName], [Salt]) VALUES (2, 2, 3, N'Student4', N'P2am6ST+mVCS1M+3OhTZIi6BTVmGLZEM7d9sN7nPolcZmhJYuGhEuMGztHePvJcgO69hps2wokGePVbvmLKP0O+I7TDkJuhTM/quiCyUEzY4FmRiXvQ8Ni5OAZ9uwkLT', N'Владислав', N'Герасимов', N'Владимирович', N'IohC/7R0+y757nfBKjFvsv6qnpx98zDbJXF5whQox8OFvH3FCxG5Ox9KodHJCcLUlpCMcf2hTuIh+2mFWSPyqbKxVnfWmtAHNFKfR0iaXkBpI06/J5LJqL2CVsL9LDUa')
GO
INSERT [dbo].[Users] ([Id], [GroupId], [RoleId], [Login], [Password], [Name], [LastName], [MiddleName], [Salt]) VALUES (3, 2, 3, N'Nik2001', N'wJ4k0Uahftv2F/RZJSnUdXjkxgWUWep9Y8sy6lC4XNGEhAYwzSScdWHjM8wwSPiHDZxpFi3cNf80Dn7UAowKYyK8r7ENGdZZXJPnOXM9xHYRDU6Bbkpc5tXco/UAPo2y', N'Алексей', N'Лыкасов', N'Владимирович', N'ks6gNUdCrm1Vg1Kp72eK3QiZALNveytimU4wPgynSuUH2SuF2lNPCaJvaJUEEZ2/v04ELCJviUAyocNRQzDqU9GXiCBJX5qV+GohS7ALrWFWVzAC4Ev70MUgHQp13j+b')
GO
INSERT [dbo].[Users] ([Id], [GroupId], [RoleId], [Login], [Password], [Name], [LastName], [MiddleName], [Salt]) VALUES (4, NULL, 1, N'Mark2001', N'cQ11zKW8i5GW5FYiyyu3iNuyNsS63IORj86XhWgy8RAF9TD5tKb/P33FaWihnICdHVZoDaSJebMVS5KyVlIr5fyQCgqQbmvVVVoh+GHnIaAl5hQx3thIFldDRLvirUz7', N'Елена', N'Парфёнова', N'Вячеславовна', N'TWOK2jO0yHlrnNYCArXVTHhTefzQ6SR76T9EMK+OPZTlRz3Iv/UGALIazGwiaE4TF2wukikxff7bMoT5ItuacnpTha9NqF3hFiIFkZHln/g2bix/kpn6Sv7/h4dtEBPk')
GO
INSERT [dbo].[Users] ([Id], [GroupId], [RoleId], [Login], [Password], [Name], [LastName], [MiddleName], [Salt]) VALUES (5, NULL, 2, N'Teacher1', N'3S4GEZfMWxvkDU4ik4Q3dn/7VW+YKBEp96Qhrb7bil3kk1RDm/B5bC8baQ9Fvw7vNLof+3WuB8ZdKCGaZ1ZaLqXa2CXmbeiyNHt/BBGA88FPrY3b+PRC9+p3uUxLnvK/', N'Дарья', N'Лыкасова', N'Евгеньевна', N'1+NYc+WpLM0ymWKKmKdmLg2YXHtGHml+bGIonr5JnMJBB8xedlBICvP9FrykZv7oxTF89iGriX1RbbfwHlyhQxKj+uF4jZki4G2uoWVJ6qpjQdVD6Eurzi4rn8XO1Oi+')
GO
INSERT [dbo].[Users] ([Id], [GroupId], [RoleId], [Login], [Password], [Name], [LastName], [MiddleName], [Salt]) VALUES (6, 1, 3, N'Mark3004', N'lJ/QecCmnPP5lpNn/W71A6x1pFhs9ZIY1k0PhSQn8Vr3ZEfNmuLTwmrBqka4A74RFdOd4GI7FrbXiWlf4jROfM6cdGAP2k6cSx1INmL2TynagR0LnMr/XyhZurHrxa32', N'Иван', N'Котов', N'Иванович', N'HzDhDnt7EFsEeK56y8BUDBiYUNfYSDYpoEcfx1NlPFI5/43Y8mSEpGVthCp9eMHkwxuShjDKZ+P0kKGFaSaermeHmKaySrdtO9PgCZ4gK1xXQk9EEXHcRBSeleaKi0rT')
GO
INSERT [dbo].[Users] ([Id], [GroupId], [RoleId], [Login], [Password], [Name], [LastName], [MiddleName], [Salt]) VALUES (7, 1, 3, N'Student1', N'+W4bdGG3Bl1Hf4qk6anVVFLhzebG/z7YijN5EwRlMIelBwgfqxSbJ6OQkyAaiELTzxh7Zx/G95SwmrPhNzighZwmuRhFH1EIdHOgKFdTM9uPIGDBNtwBS1HyKV4nAtWA', N'Сидор', N'Сидоров', N'Сидорович', N'wLjq0MkdEe/Gem3ivEziTu+FI7iBX+WGQHv43ewJbSd/kpHLicPrghVzhJp8FUdIcZecwAgXbgp/3ug9i6ID0lXyw0ykL3hU79QxZTx1wpBBBmUXwoe7dKqXkkhhisLh')
GO
INSERT [dbo].[Users] ([Id], [GroupId], [RoleId], [Login], [Password], [Name], [LastName], [MiddleName], [Salt]) VALUES (8, 2, 3, N'Student2', N'POZ3Ma4/5dE3hQWHFqi9k6dkgQPoXCbqgoijmM2twJzYSOOA11DHys2xPggC6cwx2DIUg79IbJDniKBXbcN2E9y4ZW4tJ89CPoM2zyyO8b2QcQBdRY33JMAkvJhj+9cu', N'Пётр', N'Петров', N'Алмасович', N'gR8uPyeswIzxxO4Cdyfldmp4i9A2CjbcoQ3tWyLc/NSzp3FCqBtcWWBfVo5ZY5BMZ6hzEz7n41fQANW3tLz7Jpnt3ATj1O0gkZKuaFtvYmiR2cBuWTHT4RSVIdHVsYPB')
GO
INSERT [dbo].[Users] ([Id], [GroupId], [RoleId], [Login], [Password], [Name], [LastName], [MiddleName], [Salt]) VALUES (14, NULL, 2, N'Teacher2', N'wd3b1ChshBSB5mJJ4MNWZeWtcaRn89rpPwjXydanR06dpyuDqXsSABRrGtBLIEu+sCIj+ZdC4Sk30eyURVRZnVOIYiXqsOU1H7KEFZHhbVcl8IEKP70d8i21smn7TlJV', N'Владимир', N'Филипченков', N'Святославович', N'RYrK7ipXRpPVxMQ60ZIc0za7X3o5pw+ly6G/7VdLSeIDTSjiaVkyX6tJgfF9wnM+ry34Y7FuqbJ47CFpFxD015R1hU4BSLnfIPz2LUbMEXb2khQkPjDe7wPoMQkT5Q7G')
GO
INSERT [dbo].[Users] ([Id], [GroupId], [RoleId], [Login], [Password], [Name], [LastName], [MiddleName], [Salt]) VALUES (15, 3, 3, N'Student3g', N'YQiIYQX75g4GA0CHAMDVyRMW71uwJuk/lv+jAFCwG7hTwFhCfLv7LUQoE5vbHay9ae1LbK9YIVmewKnVj1INvwzVQVdCXNXvfBr/yQHV41QaghZftVcQnA2ISOsTcUYL', N'Владимир', N'Лыкасов', N'Иванович', N'tiCCgnTE+615PFqhWsYOQp49qKtihncS4K7Iqa5Ew2qXLtgkMqi2tWYpo2CzqwiynVlIYV3S1ta4z97brqnVdFU3wECWshxxXWcqyWkJo2UEDXFaLdsboqaZdzBPZpXp')
GO
INSERT [dbo].[Users] ([Id], [GroupId], [RoleId], [Login], [Password], [Name], [LastName], [MiddleName], [Salt]) VALUES (16, NULL, 2, N'Test', N'6nKxfWyZ8FEaKZL+V1kgMQP6lQtPy0jVP9ZsHZXNOwCQiQOObHdcbbHeb8cZ8s/H6CyxMeCn5RvXLKqDFMEoxLUiKmmKs7o5M6Nb1DfeObhNFykW1j3OCaGbptXJAZb/', N'test', N'test', N'test', N'tpNttjV9RfWAcjqryy0Peu6o4cjHjHPhtX8s7pjwub9tiAiy1n/ZfNohl2G9TyP8LBtnuneRSVn14gDDOHtdhkWApZn4j9hsR1FX6YjHas4oPTCVmyGQZA3nl1fqv56q')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Subjects] ON 
GO
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (2, N'Философия')
GO
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (6, N'Логика')
GO
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (9, N'Английский язык')
GO
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (12, N'ОАИП')
GO
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (14, N'Высшая математика')
GO
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (15, N'Физ. культура')
GO
INSERT [dbo].[Subjects] ([Id], [Name]) VALUES (16, N'Классный час')
GO
SET IDENTITY_INSERT [dbo].[Subjects] OFF
GO
SET IDENTITY_INSERT [dbo].[Lessons] ON 
GO
INSERT [dbo].[Lessons] ([Id], [Date], [Homework], [Theme], [StartTime], [SubjectId], [TeacherId], [GroupId]) VALUES (2, CAST(N'2022-01-31' AS Date), N'num 20', N'thisthis', CAST(N'13:30:00' AS Time), 2, 1, 1)
GO
INSERT [dbo].[Lessons] ([Id], [Date], [Homework], [Theme], [StartTime], [SubjectId], [TeacherId], [GroupId]) VALUES (5, CAST(N'2022-01-29' AS Date), N'num 6', N'this', CAST(N'13:00:00' AS Time), 2, 1, 2)
GO
INSERT [dbo].[Lessons] ([Id], [Date], [Homework], [Theme], [StartTime], [SubjectId], [TeacherId], [GroupId]) VALUES (6, CAST(N'2022-02-18' AS Date), N'номер 7', N'такая-то', CAST(N'12:00:00' AS Time), 9, 5, 2)
GO
INSERT [dbo].[Lessons] ([Id], [Date], [Homework], [Theme], [StartTime], [SubjectId], [TeacherId], [GroupId]) VALUES (7, CAST(N'2022-01-26' AS Date), N'номер 2', N'такая-то', CAST(N'14:00:00' AS Time), 9, 5, 3)
GO
INSERT [dbo].[Lessons] ([Id], [Date], [Homework], [Theme], [StartTime], [SubjectId], [TeacherId], [GroupId]) VALUES (8, CAST(N'2022-01-29' AS Date), N'номер 7, 8', N'такая-то', CAST(N'12:30:00' AS Time), 12, 5, 2)
GO
INSERT [dbo].[Lessons] ([Id], [Date], [Homework], [Theme], [StartTime], [SubjectId], [TeacherId], [GroupId]) VALUES (9, CAST(N'2022-01-27' AS Date), N'номер 6', N'такая-то', CAST(N'16:40:00' AS Time), 12, 5, 3)
GO
INSERT [dbo].[Lessons] ([Id], [Date], [Homework], [Theme], [StartTime], [SubjectId], [TeacherId], [GroupId]) VALUES (10, CAST(N'2022-01-31' AS Date), N'номер 5', N'такая-то', CAST(N'12:30:00' AS Time), 12, 5, 3)
GO
INSERT [dbo].[Lessons] ([Id], [Date], [Homework], [Theme], [StartTime], [SubjectId], [TeacherId], [GroupId]) VALUES (11, CAST(N'2022-02-04' AS Date), NULL, NULL, CAST(N'12:30:00' AS Time), 12, 5, 3)
GO
INSERT [dbo].[Lessons] ([Id], [Date], [Homework], [Theme], [StartTime], [SubjectId], [TeacherId], [GroupId]) VALUES (12, CAST(N'2022-01-28' AS Date), N'номер 9', N'такая-то', CAST(N'12:30:00' AS Time), 12, 5, 3)
GO
INSERT [dbo].[Lessons] ([Id], [Date], [Homework], [Theme], [StartTime], [SubjectId], [TeacherId], [GroupId]) VALUES (13, CAST(N'2022-02-11' AS Date), NULL, NULL, CAST(N'02:02:00' AS Time), 2, 16, 3)
GO
INSERT [dbo].[Lessons] ([Id], [Date], [Homework], [Theme], [StartTime], [SubjectId], [TeacherId], [GroupId]) VALUES (14, CAST(N'2022-02-11' AS Date), N'test', N'test', CAST(N'00:00:00' AS Time), 12, 16, 2)
GO
INSERT [dbo].[Lessons] ([Id], [Date], [Homework], [Theme], [StartTime], [SubjectId], [TeacherId], [GroupId]) VALUES (18, CAST(N'2022-01-28' AS Date), NULL, NULL, CAST(N'13:00:00' AS Time), 16, 16, 5)
GO
SET IDENTITY_INSERT [dbo].[Lessons] OFF
GO
SET IDENTITY_INSERT [dbo].[Timetable] ON 
GO
INSERT [dbo].[Timetable] ([Id], [GroupId], [SubjectId], [UserId], [DayOfWeek], [BeginDate], [EndDate], [StartTime]) VALUES (1, 2, 2, 3, 2, CAST(N'2022-01-10' AS Date), CAST(N'2022-01-16' AS Date), CAST(N'11:00:00' AS Time))
GO
INSERT [dbo].[Timetable] ([Id], [GroupId], [SubjectId], [UserId], [DayOfWeek], [BeginDate], [EndDate], [StartTime]) VALUES (2, 2, 6, 4, 1, CAST(N'2022-01-10' AS Date), CAST(N'2022-01-16' AS Date), CAST(N'12:00:00' AS Time))
GO
INSERT [dbo].[Timetable] ([Id], [GroupId], [SubjectId], [UserId], [DayOfWeek], [BeginDate], [EndDate], [StartTime]) VALUES (12, 2, 2, 3, 1, CAST(N'2022-01-10' AS Date), CAST(N'2022-01-16' AS Date), CAST(N'15:50:00' AS Time))
GO
INSERT [dbo].[Timetable] ([Id], [GroupId], [SubjectId], [UserId], [DayOfWeek], [BeginDate], [EndDate], [StartTime]) VALUES (14, 2, 9, 5, 1, CAST(N'2022-01-17' AS Date), CAST(N'2022-01-23' AS Date), CAST(N'10:00:00' AS Time))
GO
INSERT [dbo].[Timetable] ([Id], [GroupId], [SubjectId], [UserId], [DayOfWeek], [BeginDate], [EndDate], [StartTime]) VALUES (15, 3, 12, 3, 3, CAST(N'2022-01-24' AS Date), CAST(N'2022-01-30' AS Date), CAST(N'09:30:00' AS Time))
GO
INSERT [dbo].[Timetable] ([Id], [GroupId], [SubjectId], [UserId], [DayOfWeek], [BeginDate], [EndDate], [StartTime]) VALUES (17, 1, 12, 5, 2, CAST(N'2022-01-24' AS Date), CAST(N'2022-01-29' AS Date), CAST(N'13:40:00' AS Time))
GO
INSERT [dbo].[Timetable] ([Id], [GroupId], [SubjectId], [UserId], [DayOfWeek], [BeginDate], [EndDate], [StartTime]) VALUES (18, 3, 12, 5, 3, CAST(N'2022-01-24' AS Date), CAST(N'2022-01-29' AS Date), CAST(N'12:30:00' AS Time))
GO
INSERT [dbo].[Timetable] ([Id], [GroupId], [SubjectId], [UserId], [DayOfWeek], [BeginDate], [EndDate], [StartTime]) VALUES (19, 4, 12, 5, 3, CAST(N'2022-01-24' AS Date), CAST(N'2022-01-29' AS Date), CAST(N'15:50:00' AS Time))
GO
INSERT [dbo].[Timetable] ([Id], [GroupId], [SubjectId], [UserId], [DayOfWeek], [BeginDate], [EndDate], [StartTime]) VALUES (20, 3, 12, 5, 4, CAST(N'2022-01-24' AS Date), CAST(N'2022-01-29' AS Date), CAST(N'16:40:00' AS Time))
GO
INSERT [dbo].[Timetable] ([Id], [GroupId], [SubjectId], [UserId], [DayOfWeek], [BeginDate], [EndDate], [StartTime]) VALUES (21, 3, 12, 5, 5, CAST(N'2022-01-24' AS Date), CAST(N'2022-01-29' AS Date), CAST(N'12:30:00' AS Time))
GO
INSERT [dbo].[Timetable] ([Id], [GroupId], [SubjectId], [UserId], [DayOfWeek], [BeginDate], [EndDate], [StartTime]) VALUES (22, 5, 16, 16, 5, CAST(N'2022-01-24' AS Date), CAST(N'2022-01-29' AS Date), CAST(N'13:00:00' AS Time))
GO
INSERT [dbo].[Timetable] ([Id], [GroupId], [SubjectId], [UserId], [DayOfWeek], [BeginDate], [EndDate], [StartTime]) VALUES (1009, 1, 6, 3, 1, CAST(N'2022-01-17' AS Date), CAST(N'2022-01-23' AS Date), CAST(N'21:11:00' AS Time))
GO
INSERT [dbo].[Timetable] ([Id], [GroupId], [SubjectId], [UserId], [DayOfWeek], [BeginDate], [EndDate], [StartTime]) VALUES (1011, 2, 12, 5, 1, CAST(N'2022-01-24' AS Date), CAST(N'2022-01-29' AS Date), CAST(N'12:30:00' AS Time))
GO
SET IDENTITY_INSERT [dbo].[Timetable] OFF
GO
SET IDENTITY_INSERT [dbo].[Marks] ON 
GO
INSERT [dbo].[Marks] ([Id], [Value], [StudentId], [LessonId]) VALUES (2, 8, 3, 2)
GO
INSERT [dbo].[Marks] ([Id], [Value], [StudentId], [LessonId]) VALUES (3, 9, 3, 5)
GO
INSERT [dbo].[Marks] ([Id], [Value], [StudentId], [LessonId]) VALUES (4, 10, 6, 2)
GO
INSERT [dbo].[Marks] ([Id], [Value], [StudentId], [LessonId]) VALUES (6, 9, 6, 5)
GO
INSERT [dbo].[Marks] ([Id], [Value], [StudentId], [LessonId]) VALUES (7, 7, 3, 6)
GO
INSERT [dbo].[Marks] ([Id], [Value], [StudentId], [LessonId]) VALUES (8, 10, 2, 6)
GO
INSERT [dbo].[Marks] ([Id], [Value], [StudentId], [LessonId]) VALUES (12, 6, 2, 14)
GO
INSERT [dbo].[Marks] ([Id], [Value], [StudentId], [LessonId]) VALUES (13, 9, 3, 14)
GO
SET IDENTITY_INSERT [dbo].[Marks] OFF
GO

