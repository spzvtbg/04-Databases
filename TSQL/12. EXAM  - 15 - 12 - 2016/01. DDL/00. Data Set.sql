
USE TheNerdHerd
GO

SET IDENTITY_INSERT Credentials ON
GO
INSERT INTO Credentials(Id,Email,Password)
VALUES
(1,'abarnes0@sogou.com','LOL77s'),
(2,'cburns1@geocities.com','aj8YKKJo5UnO'),
(3,'wkelly2@hud.gov','DdWBFb'),
(4,'agarza3@wikia.com','H2tSI92Bqi'),
(5,'djones4@google.pl','dcMQfy'),
(6,'jlynch5@discovery.com','jWeM8Y3nu'),
(7,'rkim6@adobe.com','m1bykyPyIjQI'),
(8,'awilliamson7@rambler.ru','5sGOhKTeCG'),
(9,'aross8@hao123.com','Aybo3x6yNB'),
(10,'jbrown9@flickr.com','vRPvwrH'),
(11,'arodrigueza@facebook.com','dg7p6GO'),
(12,'mryanb@geocities.jp','GPkK0p'),
(13,'cwrightc@flickr.com','6MxXCKJ'),
(14,'mbishopd@booking.com','YmmZukaR'),
(15,'nmedinae@last.fm','6ULGRp'),
(16,'mmorenof@nih.gov','BVVnaSy5'),
(17,'rpayneg@weather.com','VCeKYVX45ah3'),
(18,'pthompsonh@ebay.co.uk','K69HODQk'),
(19,'dpetersi@1und1.de','mTLPfx'),
(20,'ascottj@aol.com','vpAOEq5ZeQfy'),
(21,'pgrayk@geocities.com','WuhbBbyXt'),
(22,'pmorenol@chicagotribune.com','OyplcB5cgtx'),
(23,'adeanm@zdnet.com','7WW0Vfy'),
(24,'jmedinan@hostgator.com','GbSkJr'),
(25,'lsimmonso@trellian.com','UjAUPZc'),
(26,'ecoxp@rediff.com','8fbDql50'),
(27,'ewebbq@washingtonpost.com','4F12G65a'),
(28,'mmorganr@liveinternet.ru','mY2HT2kBU'),
(29,'jmillers@columbia.edu','pfGKHX8'),
(30,'mperkinst@amazon.co.uk','lCFO0hSeRt');
SET IDENTITY_INSERT Credentials OFF
GO

SET IDENTITY_INSERT Locations ON
GO
INSERT INTO Locations(Id,Latitude,Longitude)
VALUES
(1,-6.5125,106.1934),
(2,-8.5155,116.9953),
(3,49.26636,-122.95263),
(4,42.09028,25.03239),
(5,52.63744,41.45968),
(6,43.8779,25.9706),
(7,-22.9111,-68.20113),
(8,57.25363,41.10849),
(9,65.84811,24.14662),
(10,-6.56666,105.84812),
(11,14.79583,104.67017),
(12,37.9074,112.55774),
(13,30.77536,107.55001),
(14,49.4811,8.4353),
(15,10.18568,123.7344),
(16,6.66917,124.56111),
(17,50.79646,19.12409),
(18,14.53333,-91.45),
(19,5.5508,120.8815),
(20,-6.9122,111.6263),
(21,35.22,-80.7881),
(22,-8.0226,111.7362),
(23,25.83892,104.11952),
(24,-19.94583,-43.48722),
(25,45.45078,41.03866),
(26,40.35,-7.9),
(27,48.7269,2.283),
(28,48.7833,2.4667),
(29,36.04408,101.42874),
(30,-29.7175,-52.42583),
(31,6.69611,124.56611),
(32,59.2239,39.88398),
(33,53.67556,34.18722),
(34,11.70611,122.36444),
(35,48.94832,38.49166),
(36,14.5832,121.0409),
(37,33.43112,105.75843),
(38,-29.23202,-61.76917),
(39,22.25,112.59376),
(40,36.07222,14.23583);
SET IDENTITY_INSERT Locations OFF
GO

SET IDENTITY_INSERT Users ON
GO
INSERT INTO Users(Id,Nickname,Gender,Age,LocationId,CredentialId)
VALUES
(1,'sbell0','F',23,19,10),
(2,'slittle1','F',66,4,9),
(3,'atorres2','F',76,30,8),
(4,'trice3','F',43,28,7),
(5,'shanson4','F',37,14,6),
(6,'tthompson5','M',75,26,5),
(7,'pduncan6','M',60,21,4),
(8,'aphillips7','F',70,10,3),
(9,'rfowler8','M',80,37,2),
(10,'smartin9','M',47,14,1),
(11,'ahunta','M',63,NULL,20),
(12,'esimmonsb','F',56,15,21),
(13,'rphillipsc','M',61,NULL,22),
(14,'jharveyd','M',18,19,23),
(15,'acolee','F',14,40,24),
(16,'tmorrisf','F',18,6,25),
(17,'jtuckerg','M',55,25,26),
(18,'ghawkinsh','F',26,6,27),
(19,'cmillsi','M',42,11,28),
(20,'dgilbertj','M',67,20,29),
(21,'vburkek','F',20,3,30),
(22,'rlawsonl','M',20,34,19),
(23,'ppaynem','F',28,37,18),
(24,'sreidn','F',39,13,17),
(25,'tfostero','F',78,38,16),
(26,'mfoxp','F',63,NULL,15),
(27,'agreenq','M',40,8,14),
(28,'snguyenr','M',41,9,13),
(29,'kmoores','F',68,9,12),
(30,'ggrayt','M',15,29,11);
SET IDENTITY_INSERT Users OFF
GO

SET IDENTITY_INSERT Chats ON
GO
INSERT INTO Chats(Id,Title,StartDate,IsActive)
VALUES
(1,'Zoolab','20150117',0),
(2,'Flowdesk','20121121',1),
(3,'Stronghold','20110307',1),
(4,'Bamity','20131028',1),
(5,'Trippledex','20140321',1),
(6,'Alphazap','20120427',1),
(7,'Greenlam','20130702',1),
(8,'Zamit','20150917',0),
(9,'Tempsoft','20160419',1),
(10,'Toughjoyfax','20151019',1),
(11,'Lotlux','20130908',1),
(12,'Solarbreeze','20160402',0),
(13,'Bytecard','20140819',1),
(14,'Toughjoyfax','20140209',0),
(15,'Biodex','20160127',0),
(16,'Zathin','20130515',1),
(17,'Regrant','20111126',1),
(18,'Cookley','20120808',1),
(19,'Bigtax','20161112',0),
(20,'Gembucket','20141026',0),
(21,'Mat Lam Tam','20160413',1),
(22,'Quo Lux','20160505',0),
(23,'Andalax','20150424',1),
(24,'Y-Solowarm','20150215',0),
(25,'Y-Solowarm','20150729',1),
(26,'Konklux','20120105',0),
(27,'Lotlux','20150704',0),
(28,'Matsoft','20131007',0),
(29,'Tres-Zap','20121104',0),
(30,'Daltfresh','20160303',1),
(31,'Viva','20120407',0),
(32,'Cardguard','20121129',0),
(33,'Rank','20110608',0),
(34,'Prodder','20131225',1),
(35,'Konklux','20131215',1),
(36,'Voyatouch','20150712',0),
(37,'Viva','20140812',1),
(38,'Vagram','20120930',1),
(39,'Tres-Zap','20120507',1),
(40,'Tempsoft','20160207',0),
(41,'Holdlamis','20130304',0),
(42,'Sub-Ex','20150129',0),
(43,'Temp','20150119',1),
(44,'Rank','20160114',1),
(45,'Transcof','20111123',1),
(46,'Matsoft','20150128',1),
(47,'Redhold','20140628',0),
(48,'Treeflex','20160111',0),
(49,'Span','20101211',1),
(50,'Viva','20161025',0),
(51,'Stringtough','20120302',1),
(52,'Home Ing','20111121',0),
(53,'Alpha','20151017',0),
(54,'Redhold','20140313',0),
(55,'Span','20160320',1),
(56,'Subin','20130420',1),
(57,'Bytecard','20130928',1),
(58,'Ventosanzap','20110705',1),
(59,'Transcof','20131008',1),
(60,'Sonsing','20130810',1);
SET IDENTITY_INSERT Chats OFF
GO


SET IDENTITY_INSERT Messages ON
GO
INSERT INTO Messages(Id,Content,SentOn, ChatId, UserId)
VALUES
(1,'in faucibus orci luctus et ultrices posuere cubilia curae mauris','20161118',49,20),
(2,'turpis donec posuere metus vitae ipsum aliquam non mauris morbi non lectus aliquam sit amet diam in','20141007',51,14),
(3,'nulla ut erat id mauris vulputate elementum nullam varius nulla facilisi cras','20110106',21,13),
(4,'et ultrices posuere cubilia curae donec pharetra magna vestibulum aliquet ultrices erat tortor','20121125',26,22),
(5,'amet erat nulla tempus vivamus in felis eu sapien cursus vestibulum','20110630',29,7),
(6,'ultrices phasellus id sapien in sapien iaculis congue vivamus metus arcu adipiscing molestie hendrerit at','20130319',40,14),
(7,'sit amet diam in magna bibendum imperdiet nullam orci pede','20121001',1,10),
(8,'ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae','20150627',48,13),
(9,'est quam pharetra magna ac consequat metus sapien ut nunc vestibulum ante','20140924',44,30),
(10,'volutpat quam pede lobortis ligula sit amet eleifend pede libero quis orci nullam molestie nibh in lectus','20150503',57,8),
(11,'dolor morbi vel lectus in quam fringilla rhoncus mauris enim leo rhoncus','20140103',53,12),
(12,'vivamus metus arcu adipiscing molestie hendrerit at vulputate vitae nisl aenean lectus','20140502',14,20),
(13,'nibh in quis justo maecenas rhoncus aliquam lacus morbi quis tortor id nulla ultrices aliquet','20140525',56,28),
(14,'vel enim sit amet nunc viverra dapibus nulla suscipit ligula in lacus curabitur at ipsum ac tellus semper interdum mauris','20121014',23,28),
(15,'morbi quis tortor id nulla ultrices aliquet maecenas leo odio condimentum id luctus nec molestie sed justo','20140328',37,12),
(16,'non pretium quis lectus suspendisse potenti in eleifend quam a odio in hac habitasse platea dictumst','20140519',50,7),
(17,'vulputate nonummy maecenas tincidunt lacus at velit vivamus vel nulla eget eros elementum pellentesque quisque porta volutpat erat','20160512',6,27),
(18,'ac consequat metus sapien ut nunc vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere','20110615',34,18),
(19,'id mauris vulputate elementum nullam varius nulla facilisi cras non velit nec nisi vulputate nonummy maecenas tincidunt lacus at','20161114',32,22),
(20,'elit sodales scelerisque mauris sit amet eros suspendisse accumsan tortor quis turpis sed ante vivamus tortor duis mattis egestas','20120503',48,10),
(21,'ornare imperdiet sapien urna pretium nisl ut volutpat sapien arcu sed augue','20120914',57,19),
(22,'ante vel ipsum praesent blandit lacinia erat vestibulum sed magna at nunc commodo placerat praesent blandit','20130511',22,22),
(23,'sem mauris laoreet ut rhoncus aliquet pulvinar sed nisl nunc rhoncus dui vel','20120415',26,11),
(24,'in lectus pellentesque at nulla suspendisse potenti cras in purus eu magna vulputate luctus cum sociis natoque penatibus','20110315',51,14),
(25,'quisque porta volutpat erat quisque erat eros viverra eget congue eget semper rutrum nulla nunc purus phasellus in felis','20160626',44,2),
(26,'lobortis sapien sapien non mi integer ac neque duis bibendum morbi non quam','20150707',55,5),
(27,'ut blandit non interdum in ante vestibulum ante ipsum primis in faucibus orci luctus','20150813',7,13),
(28,'lacus morbi quis tortor id nulla ultrices aliquet maecenas leo odio condimentum id','20131020',32,11),
(29,'laoreet ut rhoncus aliquet pulvinar sed nisl nunc rhoncus dui vel sem sed sagittis nam congue risus','20141027',37,11),
(30,'cras in purus eu magna vulputate luctus cum sociis natoque','20110509',59,3),
(31,'velit id pretium iaculis diam erat fermentum justo nec condimentum neque sapien placerat ante nulla justo aliquam quis','20160822',53,9),
(32,'luctus et ultrices posuere cubilia curae donec pharetra magna vestibulum','20120518',54,29),
(33,'aliquam quis turpis eget elit sodales scelerisque mauris sit amet eros','20141227',31,15),
(34,'in lectus pellentesque at nulla suspendisse potenti cras in purus eu magna vulputate luctus cum sociis natoque penatibus','20150330',3,26),
(35,'consequat dui nec nisi volutpat eleifend donec ut dolor morbi vel lectus in quam fringilla','20120507',12,19),
(36,'faucibus orci luctus et ultrices posuere cubilia curae nulla dapibus','20160915',50,7),
(37,'feugiat non pretium quis lectus suspendisse potenti in eleifend quam','20110307',37,23),
(38,'eu est congue elementum in hac habitasse platea dictumst morbi vestibulum velit id','20130805',45,8),
(39,'amet cursus id turpis integer aliquet massa id lobortis convallis tortor risus dapibus augue vel accumsan','20110221',17,25),
(40,'orci luctus et ultrices posuere cubilia curae mauris viverra diam vitae quam suspendisse potenti nullam porttitor lacus at turpis','20130807',2,9),
(41,'varius integer ac leo pellentesque ultrices mattis odio donec vitae nisi nam ultrices libero non mattis','20110630',13,21),
(42,'pede ullamcorper augue a suscipit nulla elit ac nulla sed vel','20160401',41,26),
(43,'platea dictumst maecenas ut massa quis augue luctus tincidunt nulla mollis molestie lorem quisque ut erat curabitur gravida nisi','20131109',35,9),
(44,'in consequat ut nulla sed accumsan felis ut at dolor quis odio consequat varius integer','20160822',15,7),
(45,'at turpis a pede posuere nonummy integer non velit donec diam neque vestibulum eget','20150427',54,6),
(46,'leo pellentesque ultrices mattis odio donec vitae nisi nam ultrices libero non mattis pulvinar nulla pede','20130709',42,25),
(47,'magnis dis parturient montes nascetur ridiculus mus vivamus vestibulum sagittis','20120711',38,28),
(48,'orci pede venenatis non sodales sed tincidunt eu felis fusce posuere felis sed lacus morbi sem mauris laoreet ut rhoncus','20120204',22,12),
(49,'nunc viverra dapibus nulla suscipit ligula in lacus curabitur at ipsum ac tellus semper interdum mauris ullamcorper','20150610',39,20),
(50,'ut suscipit a feugiat et eros vestibulum ac est lacinia nisi','20120906',45,26),
(51,'et magnis dis parturient montes nascetur ridiculus mus vivamus vestibulum sagittis sapien cum sociis natoque penatibus et','20120423',16,29),
(52,'ligula in lacus curabitur at ipsum ac tellus semper interdum mauris ullamcorper purus sit amet nulla','20110924',13,30),
(53,'magna at nunc commodo placerat praesent blandit nam nulla integer pede','20110622',4,25),
(54,'eu nibh quisque id justo sit amet sapien dignissim vestibulum vestibulum ante ipsum primis','20110426',7,15),
(55,'ultrices posuere cubilia curae duis faucibus accumsan odio curabitur convallis duis consequat dui nec nisi volutpat','20130110',22,2),
(56,'lacus at turpis donec posuere metus vitae ipsum aliquam non mauris','20140530',32,12),
(57,'venenatis tristique fusce congue diam id ornare imperdiet sapien urna pretium nisl ut volutpat sapien arcu sed','20160126',57,11),
(58,'ac diam cras pellentesque volutpat dui maecenas tristique est et tempus semper est','20120423',8,1),
(59,'donec pharetra magna vestibulum aliquet ultrices erat tortor sollicitudin mi sit amet lobortis sapien sapien non mi','20141029',37,19),
(60,'sagittis nam congue risus semper porta volutpat quam pede lobortis ligula sit amet eleifend pede libero quis orci nullam molestie','20150717',12,10),
(61,'ac tellus semper interdum mauris ullamcorper purus sit amet nulla quisque arcu libero rutrum ac lobortis vel dapibus at','20120326',38,11),
(62,'sem fusce consequat nulla nisl nunc nisl duis bibendum felis sed interdum venenatis turpis enim blandit mi','20131017',8,2),
(63,'ultrices posuere cubilia curae nulla dapibus dolor vel est donec odio justo sollicitudin ut suscipit a feugiat et','20160721',46,12),
(64,'ac tellus semper interdum mauris ullamcorper purus sit amet nulla quisque arcu libero rutrum ac lobortis vel dapibus at diam','20130926',53,23),
(65,'est et tempus semper est quam pharetra magna ac consequat metus sapien ut nunc vestibulum ante ipsum primis in faucibus','20101222',17,24),
(66,'mi sit amet lobortis sapien sapien non mi integer ac neque duis bibendum morbi non quam nec dui luctus rutrum','20151013',45,18),
(67,'ut dolor morbi vel lectus in quam fringilla rhoncus mauris','20120717',2,18),
(68,'est donec odio justo sollicitudin ut suscipit a feugiat et','20150824',36,1),
(69,'augue vestibulum rutrum rutrum neque aenean auctor gravida sem praesent id massa id nisl venenatis lacinia aenean','20120920',33,29),
(70,'faucibus accumsan odio curabitur convallis duis consequat dui nec nisi volutpat eleifend donec ut dolor morbi vel lectus in','20151115',12,7),
(71,'sociis natoque penatibus et magnis dis parturient montes nascetur ridiculus mus','20160304',17,19),
(72,'donec quis orci eget orci vehicula condimentum curabitur in libero','20110330',5,18),
(73,'augue vel accumsan tellus nisi eu orci mauris lacinia sapien quis libero nullam sit amet turpis','20110713',7,21),
(74,'dolor sit amet consectetuer adipiscing elit proin interdum mauris non ligula','20160718',46,23),
(75,'bibendum imperdiet nullam orci pede venenatis non sodales sed tincidunt eu felis fusce posuere','20111215',35,24),
(76,'eu orci mauris lacinia sapien quis libero nullam sit amet turpis elementum ligula vehicula consequat','20111216',10,4),
(77,'amet diam in magna bibendum imperdiet nullam orci pede venenatis non sodales sed tincidunt eu felis fusce posuere felis','20141224',10,25),
(78,'ultrices libero non mattis pulvinar nulla pede ullamcorper augue a suscipit','20160330',55,19),
(79,'justo sit amet sapien dignissim vestibulum vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia','20150924',40,11),
(80,'sapien iaculis congue vivamus metus arcu adipiscing molestie hendrerit at vulputate vitae nisl aenean lectus pellentesque eget nunc','20120409',33,12),
(81,'non mauris morbi non lectus aliquam sit amet diam in magna bibendum imperdiet nullam orci pede venenatis non','20140111',50,8),
(82,'quam suspendisse potenti nullam porttitor lacus at turpis donec posuere metus vitae ipsum aliquam non mauris morbi non lectus aliquam','20131219',60,21),
(83,'sit amet turpis elementum ligula vehicula consequat morbi a ipsum integer a nibh in quis justo maecenas rhoncus aliquam lacus','20140423',11,4),
(84,'pede justo lacinia eget tincidunt eget tempus vel pede morbi porttitor','20120821',25,3),
(85,'pede ac diam cras pellentesque volutpat dui maecenas tristique est et tempus semper est quam pharetra magna','20111004',44,27),
(86,'a pede posuere nonummy integer non velit donec diam neque vestibulum eget vulputate ut ultrices vel augue vestibulum ante','20130131',23,9),
(87,'justo sollicitudin ut suscipit a feugiat et eros vestibulum ac est lacinia','20140704',52,1),
(88,'odio cras mi pede malesuada in imperdiet et commodo vulputate justo in','20140730',43,18),
(89,'non sodales sed tincidunt eu felis fusce posuere felis sed lacus morbi sem mauris laoreet','20150809',18,3),
(90,'amet diam in magna bibendum imperdiet nullam orci pede venenatis non sodales sed tincidunt eu felis fusce posuere','20101214',47,2),
(91,'erat nulla tempus vivamus in felis eu sapien cursus vestibulum proin','20160216',21,15),
(92,'nibh in lectus pellentesque at nulla suspendisse potenti cras in purus eu magna vulputate luctus cum sociis natoque','20110304',15,18),
(93,'sapien iaculis congue vivamus metus arcu adipiscing molestie hendrerit at vulputate vitae nisl aenean lectus','20130101',26,10),
(94,'aliquam quis turpis eget elit sodales scelerisque mauris sit amet eros suspendisse accumsan','20150228',15,16),
(95,'tortor duis mattis egestas metus aenean fermentum donec ut mauris eget','20140718',40,27),
(96,'mauris non ligula pellentesque ultrices phasellus id sapien in sapien iaculis congue vivamus metus arcu adipiscing molestie hendrerit at','20120228',24,12),
(97,'nec sem duis aliquam convallis nunc proin at turpis a pede posuere nonummy','20130728',42,2),
(98,'posuere cubilia curae mauris viverra diam vitae quam suspendisse potenti nullam','20150921',14,23),
(99,'vulputate nonummy maecenas tincidunt lacus at velit vivamus vel nulla','20150502',58,10),
(100,'pretium iaculis diam erat fermentum justo nec condimentum neque sapien placerat ante nulla justo','20120709',32,18);
SET IDENTITY_INSERT Messages OFF
GO

INSERT INTO UsersChats(UserId,ChatId)
VALUES
(7,30),
(30,43),
(9,36),
(21,13),
(23,28),
(6,36),
(8,36),
(19,39),
(1,55),
(30,53),
(21,59),
(24,59),
(13,44),
(19,17),
(25,54),
(3,33),
(2,27),
(29,2),
(10,20),
(16,39),
(15,10),
(27,10),
(27,18),
(17,42),
(10,32),
(4,35),
(10,2),
(3,41),
(18,16),
(23,19),
(20,2),
(24,43),
(7,27),
(27,29),
(24,32),
(6,10),
(5,15),
(10,8),
(27,5),
(3,18),
(22,59),
(1,28),
(20,59),
(26,16),
(21,54),
(7,20),
(5,57),
(21,48),
(5,20),
(24,21);