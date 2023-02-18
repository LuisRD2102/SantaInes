INSERT INTO dbo.Departamentos values ('77033F54-C19A-4036-8E75-B032D92AE90D','Enfermeria','Laboratorio de enfermeria')
INSERT INTO dbo.Departamentos values ('10356C66-569F-41EF-99E2-83070A04628D','Medicina General','Laboratorio de Medicina General')
INSERT INTO dbo.Departamentos values ('A8A48205-5FFB-42AD-8567-1639DB6A60A7','Secretaría','Secretaria general')
INSERT INTO dbo.Departamentos values ('D2C8EA80-8AC1-4CFB-98AD-F33F055310EF','Gerencia','Gerencia general')



INSERT INTO dbo.Direccion values ('82348632-9A01-441A-92B5-08EB4752AD64','Libertador','Centro-sur calle 2',1014)
INSERT INTO dbo.Direccion values ('BBFABEC2-D7DA-449D-9D74-656FE20CAFA7','Libertador','Calle 5 intesección UCV',1053)
INSERT INTO dbo.Direccion values ('AA6C0B77-3C5D-4D04-8A15-660171326B2F','Chacao','Ocatava avenida parque chacao',1060)
INSERT INTO dbo.Direccion values ('B4901987-5F75-46E2-A143-8C0FAB47232C','Chacao','Octava avenida parque chacao',1080)


INSERT INTO dbo.HistoriaMedicas (idHistoria) values ('8fa67439-030a-430f-821a-08db0e284e2d');
INSERT INTO dbo.HistoriaMedicas (idHistoria) values ('474e6779-7ed2-4e6c-0c19-08db0e2d1c88');
INSERT INTO dbo.HistoriaMedicas (idHistoria) values ('3f89886a-a641-4f06-0c1b-08db0e2d1c88');
INSERT INTO dbo.HistoriaMedicas (idHistoria) values ('b642e124-fe8f-4b88-f93e-08db0e2ea13c');


INSERT INTO dbo.Usuario values ('pedro','12345678',27666123,'Pedro Carlos','Santana Gomez','1990-01-01','M','(416) 123-1231','pedrogmz@gmail.com','82348632-9A01-441A-92B5-08EB4752AD64', '8fa67439-030a-430f-821a-08db0e284e2d')
INSERT INTO dbo.Usuario values ('luis','12345678',12345678,'Luis','Herrera Sandoval','2000-02-03','M','(424) 123-1231','luisHerare@gmail.com','BBFABEC2-D7DA-449D-9D74-656FE20CAFA7','474e6779-7ed2-4e6c-0c19-08db0e2d1c88')
INSERT INTO dbo.Usuario values ('lmromero.18','a',12345699,'Luis','Gutierrez Marquez','2001-02-03','M','(414) 123-1231','luisGutierrez@gmail.com','B4901987-5F75-46E2-A143-8C0FAB47232C','3f89886a-a641-4f06-0c1b-08db0e2d1c88')
INSERT INTO dbo.Usuario values ('amanda','12345678',12345678,'Amanda Luisa','Fernandez','2002-06-09','F','(416) 123-1231','lamanda@gmail.com','AA6C0B77-3C5D-4D04-8A15-660171326B2F','b642e124-fe8f-4b88-f93e-08db0e2ea13c')


INSERT INTO dbo.Empleados values ('doc1','12345678',28273612,'Juan Fernando','Caires Montreal','Doctor','77033F54-C19A-4036-8E75-B032D92AE90D','M')
INSERT INTO dbo.Empleados values ('doc2','12345678',28111999,'Carla Maria','Montilla','Doctor','10356C66-569F-41EF-99E2-83070A04628D','F')
INSERT INTO dbo.Empleados values ('secretaria1','12345678',19837822,'Maria','Ramirez','Secretaria','A8A48205-5FFB-42AD-8567-1639DB6A60A7','M')
INSERT INTO dbo.Empleados values ('gerente1','12345678',27333123,'Adrian','Monsalve','Gerencia','D2C8EA80-8AC1-4CFB-98AD-F33F055310EF','M')
INSERT INTO dbo.Empleados values ('presidente1','12345678',27888444,'Henry','Castillo','Presidencia',null,'M')

