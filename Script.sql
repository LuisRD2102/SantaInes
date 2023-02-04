INSERT INTO dbo.Departamentos values ('77033F54-C19A-4036-8E75-B032D92AE90D','Enfermeria','Laboratorio de enfermeria')
INSERT INTO dbo.Departamentos values ('10356C66-569F-41EF-99E2-83070A04628D','Medicina General','Laboratorio de Medicina General')
INSERT INTO dbo.Departamentos values ('A8A48205-5FFB-42AD-8567-1639DB6A60A7','Secretaria','Secretaria general')


INSERT INTO dbo.Itinerarios values ('87B6928E-7E95-4067-96FC-A3595EB5DDF1','2023-01-27 7:00:00','2023-01-27 19:00:00')
INSERT INTO dbo.Itinerarios values ('E208E0D7-1AEF-4A8F-AFB7-62CF8C431186','2023-01-27 9:00:00','2023-01-27 18:00:00')


INSERT INTO dbo.Direccion values ('82348632-9A01-441A-92B5-08EB4752AD64','Libertador','Centro-sur calle 2',1014)
INSERT INTO dbo.Direccion values ('BBFABEC2-D7DA-449D-9D74-656FE20CAFA7','Libertador','Calle 5 intesección UCV',1053)
INSERT INTO dbo.Direccion values ('AA6C0B77-3C5D-4D04-8A15-660171326B2F','Chacao','Ocatava avenida parque chacao',1060)


INSERT INTO dbo.Usuario values ('pedro','12345678',27666123,'Pedro Carlos','Santana Gomez','1990-01-01','M','4128762931','pedrogmz@gmail.com','82348632-9A01-441A-92B5-08EB4752AD64')
INSERT INTO dbo.Usuario values ('luis','12345678',12345678,'Luis','Herrera Sandoval','2000-02-03','M','416928371','luisHerare@gmail.com','BBFABEC2-D7DA-449D-9D74-656FE20CAFA7')
INSERT INTO dbo.Usuario values ('lmromero.18','a',12345678,'Luis','Gutierrez Marquez','2001-02-03','M','416928371','luisGutierrez@gmail.com','BBFABEC2-D7DA-449D-9D74-656FE20CAFA7')
INSERT INTO dbo.Usuario values ('amanda','12345678',12345678,'Amanda Luisa','Fernandez','2002-06-09','F','424002211','lamanda@gmail.com','AA6C0B77-3C5D-4D04-8A15-660171326B2F')


INSERT INTO dbo.Empleados values ('doc1','12345678',28273612,'Juan Fernando','Caires Montreal','Doctor','77033F54-C19A-4036-8E75-B032D92AE90D','87B6928E-7E95-4067-96FC-A3595EB5DDF1','M')
INSERT INTO dbo.Empleados values ('doc2','12345678',28111999,'Carla Maria','Montilla','Doctor','10356C66-569F-41EF-99E2-83070A04628D','E208E0D7-1AEF-4A8F-AFB7-62CF8C431186','F')
INSERT INTO dbo.Empleados values ('emp1','12345678',19837822,'Rolando','Ramirez','Empleado','A8A48205-5FFB-42AD-8567-1639DB6A60A7',null,'M')


INSERT INTO dbo.Citas values ('87D3423C-42AC-4947-B175-81EC837706BF','2023-01-27 9:00:00','pedro','doc1')
INSERT INTO dbo.Citas values ('AAFDBFE4-F83B-4E8E-BBC9-2328C1DBEC0D','2023-01-27 12:00:00','luis','doc2')
INSERT INTO dbo.Citas values ('4EDBA153-903A-442C-961D-25DF58352A19','2023-01-27 13:00:00','amanda','doc1')

