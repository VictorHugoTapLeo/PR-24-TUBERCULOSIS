-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: tuberculosis
-- ------------------------------------------------------
-- Server version	8.0.37

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `baciloscopia`
--

DROP TABLE IF EXISTS `baciloscopia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `baciloscopia` (
  `idBaciloscopia` int NOT NULL AUTO_INCREMENT,
  `numBaciloscopia` tinyint DEFAULT NULL,
  `fechaBaciloscopia` datetime DEFAULT NULL,
  `resultado` varchar(10) DEFAULT NULL COMMENT '\n',
  `estado` tinyint(1) NOT NULL DEFAULT '1',
  `fechaCreacion` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `fechaActualizacion` datetime DEFAULT NULL,
  PRIMARY KEY (`idBaciloscopia`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `baciloscopia`
--

LOCK TABLES `baciloscopia` WRITE;
/*!40000 ALTER TABLE `baciloscopia` DISABLE KEYS */;
/*!40000 ALTER TABLE `baciloscopia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cardex`
--

DROP TABLE IF EXISTS `cardex`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cardex` (
  `idCardex` int NOT NULL AUTO_INCREMENT,
  `tipoTuberculosis` varchar(45) NOT NULL,
  `saturacion` varchar(10) NOT NULL,
  `frecuenciaCardiaca` varchar(10) NOT NULL,
  `frecuenciaRespiratoria` varchar(10) NOT NULL,
  `diagnosticadoPor` int NOT NULL COMMENT 'Tiene los valores:\\n- Baciloscopia\\n- GeneXpert\\n- Cultivo\\n- Clinicamente',
  `fechaCreacion` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `fechaActualizacion` datetime DEFAULT NULL,
  `estado` tinyint(1) NOT NULL DEFAULT '1',
  `Persona_idPersona` int NOT NULL,
  `docificacionMedicamentos` varchar(45) NOT NULL,
  `numeroDosis` varchar(45) NOT NULL,
  `cultivo` varchar(45) NOT NULL,
  `basiloscopia` varchar(45) NOT NULL,
  PRIMARY KEY (`idCardex`),
  KEY `fk_Cardex_Persona1_idx` (`Persona_idPersona`),
  CONSTRAINT `fk_Cardex_Persona1` FOREIGN KEY (`Persona_idPersona`) REFERENCES `persona` (`idPersona`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cardex`
--

LOCK TABLES `cardex` WRITE;
/*!40000 ALTER TABLE `cardex` DISABLE KEYS */;
INSERT INTO `cardex` VALUES (1,'1','1','1','1',11,'2024-06-09 14:07:41',NULL,1,4,'1','1','1','1'),(2,'1','1','1','1',1,'2024-06-09 15:38:11',NULL,1,1,'1','1','1','1'),(3,'Ganglionar','123','123','123',1,'2024-06-09 15:40:43',NULL,1,4,'123','123','123','123'),(4,'Ganglionar','dfhd','dfhdf','dfh',1,'2024-06-09 17:33:47',NULL,1,4,'hdfhfd','dfh','dfhdf','dfhdfh'),(5,'Ganglionar','123','123','123',1,'2024-06-09 23:22:03',NULL,1,15,'123','123','123','123'),(6,'Ganglionar','123','3123','31',1,'2024-06-11 22:21:34',NULL,1,4,'hola','hola','hola','hola'),(7,'Ganglionar','123','123','123',1,'2024-06-11 23:04:07',NULL,1,6,'123','123','213','123'),(8,'Genitourinaria','qwe','qwe','qwe',1,'2024-06-11 23:06:48',NULL,1,6,'qwe','qwe','qwe','qwe'),(9,'Ganglionar','123','123','123',1,'2024-06-11 23:12:09',NULL,1,12,'123','123','123','123'),(10,'Ganglionar','123','123','3',1,'2024-06-11 23:12:24',NULL,1,19,'123','123','123','123'),(11,'Ganglionar','123','123','123',1,'2024-06-11 23:20:00',NULL,1,20,'123','123','123','123'),(12,'Ganglionar','33','777','666',22,'2024-06-12 09:21:11',NULL,1,17,'none','2','cultivo 1','positivo'),(13,'Ganglionar','ejemplo','ejemplo','ejemplo',1,'2024-06-14 19:00:24',NULL,1,24,'ejemplo','ejemplo','ejemplo','ejemplo'),(14,'Ganglionar','prueba','prueba','prueba',1,'2024-06-14 19:17:13',NULL,1,24,'prueba','prueba','prueba','prueba'),(15,'Ganglionar','ejemplo','ejemplo','ejemplo',1,'2024-06-24 09:14:28',NULL,1,15,'ejemplo','ejemplo','ejemplo','ejemplo');
/*!40000 ALTER TABLE `cardex` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `controltratamiento`
--

DROP TABLE IF EXISTS `controltratamiento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `controltratamiento` (
  `idControlTratamiento` int NOT NULL AUTO_INCREMENT,
  `basiloscopia` varchar(45) NOT NULL,
  `cultivo` varchar(45) NOT NULL,
  `aumentoDosis` varchar(45) NOT NULL,
  `fechaCreacion` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `fechaActualizacion` datetime DEFAULT NULL,
  `estado` tinyint NOT NULL DEFAULT '1',
  `persona_idPersona` int NOT NULL,
  `orden_idorden` int NOT NULL,
  PRIMARY KEY (`idControlTratamiento`),
  KEY `fk_controltratamiento_persona1_idx` (`persona_idPersona`),
  KEY `fk_controltratamiento_orden1_idx` (`orden_idorden`),
  CONSTRAINT `fk_controltratamiento_orden1` FOREIGN KEY (`orden_idorden`) REFERENCES `orden` (`idorden`),
  CONSTRAINT `fk_controltratamiento_persona1` FOREIGN KEY (`persona_idPersona`) REFERENCES `persona` (`idPersona`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `controltratamiento`
--

LOCK TABLES `controltratamiento` WRITE;
/*!40000 ALTER TABLE `controltratamiento` DISABLE KEYS */;
INSERT INTO `controltratamiento` VALUES (1,'Positivo','Negativo','+1','2024-06-09 20:43:10',NULL,1,15,2),(2,'Negativo','Negativo','+1','2024-06-09 21:11:22',NULL,1,12,1),(3,'Negativo','Negativo','+1','2024-06-09 21:24:59',NULL,1,15,4),(4,'Positivo','Negativo','+1','2024-06-11 22:23:29',NULL,1,4,1),(5,'Positivo','Positivo','F','2024-06-12 09:24:17',NULL,1,17,4),(6,'Negativo','Positivo','+1','2024-06-14 19:01:10',NULL,1,24,1),(7,'Negativo','Negativo','+1','2024-06-14 19:02:01',NULL,1,24,2),(8,'Negativo','Negativo','+1','2024-06-14 19:19:33',NULL,1,15,3);
/*!40000 ALTER TABLE `controltratamiento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `coordianacionredsalud`
--

DROP TABLE IF EXISTS `coordianacionredsalud`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `coordianacionredsalud` (
  `idCoordianacionRedSalud` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) NOT NULL,
  `estado` tinyint(1) NOT NULL DEFAULT '1',
  `fechaCreacion` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `fechaActualizacion` datetime DEFAULT NULL,
  `Hospital_idHospital` int NOT NULL,
  PRIMARY KEY (`idCoordianacionRedSalud`),
  KEY `fk_CoordianacionRedSalud_Hospital1_idx` (`Hospital_idHospital`),
  CONSTRAINT `fk_CoordianacionRedSalud_Hospital1` FOREIGN KEY (`Hospital_idHospital`) REFERENCES `hospital` (`idHospital`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `coordianacionredsalud`
--

LOCK TABLES `coordianacionredsalud` WRITE;
/*!40000 ALTER TABLE `coordianacionredsalud` DISABLE KEYS */;
/*!40000 ALTER TABLE `coordianacionredsalud` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cultivo`
--

DROP TABLE IF EXISTS `cultivo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cultivo` (
  `idCultivo` int NOT NULL AUTO_INCREMENT,
  `numCultivo` tinyint DEFAULT NULL,
  `fechaCultivo` datetime DEFAULT NULL,
  `resultado` varchar(10) DEFAULT NULL COMMENT 'Resultados:\n- POSITIVO\n- NEGATIVO',
  `estado` tinyint(1) NOT NULL DEFAULT '1',
  `fechaCreacion` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `fechaActualizacion` datetime DEFAULT NULL,
  PRIMARY KEY (`idCultivo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cultivo`
--

LOCK TABLES `cultivo` WRITE;
/*!40000 ALTER TABLE `cultivo` DISABLE KEYS */;
/*!40000 ALTER TABLE `cultivo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `diagnostico`
--

DROP TABLE IF EXISTS `diagnostico`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `diagnostico` (
  `idDiagnostico` int NOT NULL AUTO_INCREMENT,
  `baciloscopiaMuestra1` varchar(10) DEFAULT NULL,
  `baciloscopiaMuestra2` varchar(10) DEFAULT NULL,
  `cultivo` varchar(10) DEFAULT NULL,
  `genExpert` varchar(45) DEFAULT NULL,
  `fechaRegistro` datetime DEFAULT NULL,
  `pesoInicial` tinyint DEFAULT NULL,
  `estado` tinyint(1) NOT NULL DEFAULT '1',
  `fechaCreacion` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `fechaActualizacion` datetime DEFAULT NULL,
  `Persona_idPersona` int NOT NULL,
  PRIMARY KEY (`idDiagnostico`),
  KEY `fk_Diagnostico_Persona1_idx` (`Persona_idPersona`),
  CONSTRAINT `fk_Diagnostico_Persona1` FOREIGN KEY (`Persona_idPersona`) REFERENCES `persona` (`idPersona`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `diagnostico`
--

LOCK TABLES `diagnostico` WRITE;
/*!40000 ALTER TABLE `diagnostico` DISABLE KEYS */;
INSERT INTO `diagnostico` VALUES (1,'Positivo',NULL,'Positivo','Detectado','2024-06-02 21:23:29',1,1,'2024-06-02 21:23:29',NULL,11),(2,NULL,NULL,NULL,NULL,'2024-06-02 21:24:04',0,1,'2024-06-02 21:24:03',NULL,4),(3,'Positivo',NULL,'Negativo','Detectado','2024-06-03 04:00:24',1,1,'2024-06-03 04:00:24',NULL,13),(4,'Negativo',NULL,'Negativo','Detectado','2024-06-09 18:20:06',1,1,'2024-06-09 18:20:05',NULL,15),(5,'Positivo',NULL,'Negativo','No detectado','2024-06-09 21:08:49',1,1,'2024-06-09 21:08:49',NULL,12),(6,'Positivo',NULL,'Positivo','No detectado','2024-06-11 22:20:08',1,1,'2024-06-11 22:20:08',NULL,19),(7,'Negativo',NULL,'Negativo','No detectado','2024-06-11 23:19:44',1,1,'2024-06-11 23:19:44',NULL,20),(8,'Positivo',NULL,'Positivo','Detectado','2024-06-12 09:19:54',1,1,'2024-06-12 09:19:54',NULL,17),(9,'Negativo',NULL,'Negativo','No detectado','2024-06-14 18:59:46',1,1,'2024-06-14 18:59:45',NULL,24),(10,'Negativo',NULL,'Negativo','No detectado','2024-06-14 19:48:51',1,1,'2024-06-14 19:48:51',NULL,25);
/*!40000 ALTER TABLE `diagnostico` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `hospital`
--

DROP TABLE IF EXISTS `hospital`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `hospital` (
  `idHospital` int NOT NULL AUTO_INCREMENT,
  `nombreHospital` varchar(35) NOT NULL,
  `nivel` tinyint NOT NULL DEFAULT '3' COMMENT 'Hay tres tipos de valores: 1, 2 y 3',
  `estado` tinyint(1) NOT NULL DEFAULT '1',
  `fechaCreacion` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `fechaActualizacion` datetime DEFAULT NULL,
  `Municipio_idMunicipio` int NOT NULL,
  `sede` varchar(35) DEFAULT NULL,
  PRIMARY KEY (`idHospital`),
  KEY `fk_Hospital_Municipio1_idx` (`Municipio_idMunicipio`),
  CONSTRAINT `fk_Hospital_Municipio1` FOREIGN KEY (`Municipio_idMunicipio`) REFERENCES `municipio` (`idMunicipio`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hospital`
--

LOCK TABLES `hospital` WRITE;
/*!40000 ALTER TABLE `hospital` DISABLE KEYS */;
INSERT INTO `hospital` VALUES (1,'Los Angles',2,1,'2024-05-21 17:58:09',NULL,1,NULL);
/*!40000 ALTER TABLE `hospital` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `medicacion`
--

DROP TABLE IF EXISTS `medicacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `medicacion` (
  `idMedicacion` int NOT NULL AUTO_INCREMENT,
  `nombreMedicacion` varchar(450) NOT NULL,
  `gramaje` int DEFAULT NULL,
  `estado` tinyint(1) NOT NULL DEFAULT '1',
  `fechaCreacion` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `fechaActualizacion` datetime DEFAULT NULL,
  PRIMARY KEY (`idMedicacion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `medicacion`
--

LOCK TABLES `medicacion` WRITE;
/*!40000 ALTER TABLE `medicacion` DISABLE KEYS */;
/*!40000 ALTER TABLE `medicacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `municipio`
--

DROP TABLE IF EXISTS `municipio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `municipio` (
  `idMunicipio` int NOT NULL AUTO_INCREMENT,
  `nombreMunicipio` varchar(50) NOT NULL,
  `estado` tinyint(1) NOT NULL DEFAULT '1',
  `fechaCreacion` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `fechaActualizacion` datetime DEFAULT NULL,
  `Region_idRegion` int NOT NULL,
  PRIMARY KEY (`idMunicipio`),
  KEY `fk_Municipio_Region1_idx` (`Region_idRegion`),
  CONSTRAINT `fk_Municipio_Region1` FOREIGN KEY (`Region_idRegion`) REFERENCES `region` (`idRegion`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `municipio`
--

LOCK TABLES `municipio` WRITE;
/*!40000 ALTER TABLE `municipio` DISABLE KEYS */;
INSERT INTO `municipio` VALUES (1,'cercado',1,'2024-05-21 17:56:32',NULL,1);
/*!40000 ALTER TABLE `municipio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orden`
--

DROP TABLE IF EXISTS `orden`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orden` (
  `idorden` int NOT NULL AUTO_INCREMENT,
  `enumeracionOrden` varchar(45) NOT NULL,
  PRIMARY KEY (`idorden`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orden`
--

LOCK TABLES `orden` WRITE;
/*!40000 ALTER TABLE `orden` DISABLE KEYS */;
INSERT INTO `orden` VALUES (1,'primer'),(2,'segund'),(3,'tercer'),(4,'cuart'),(5,'quint'),(6,'sext');
/*!40000 ALTER TABLE `orden` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `paciente`
--

DROP TABLE IF EXISTS `paciente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `paciente` (
  `idPaciente` int NOT NULL,
  `latitud` int NOT NULL,
  `longitud` int NOT NULL,
  `fechaNacimiento` datetime NOT NULL,
  `ultimaActualizacion` datetime NOT NULL,
  `condicion` varchar(15) NOT NULL DEFAULT 'NO EVALUADO' COMMENT 'La condicion se refiere al estado de actividad del paciente hay:\n- CURADO\n- COMPLETADO\n- FRACASO\n- FALLECIDO\n- PERDIDA\n- NO EVALUADO\n- TRANSFERENCIA',
  `numAuxiliar1` int NOT NULL,
  `numAuxiliar2` int NOT NULL,
  `codigoPaciente` varchar(15) DEFAULT NULL,
  `codigoQR` varchar(15) DEFAULT NULL,
  `pesoInicial` varchar(10) DEFAULT NULL COMMENT 'se mide en kilogramos',
  `pesoFinal` varchar(10) DEFAULT NULL COMMENT 'se mide en kilogramos como texto "65kg"',
  `sexo` tinyint(1) NOT NULL COMMENT 'Hombre: 0\nMujer: 1',
  `Embarazo` tinyint(1) DEFAULT '0' COMMENT '1: si\n0: no',
  `talla` int DEFAULT NULL COMMENT 'Estatura del paciente en cm "171"',
  `direccion` varchar(200) NOT NULL,
  KEY `fk_table1_Persona_idx` (`idPaciente`),
  CONSTRAINT `fk_table1_Persona` FOREIGN KEY (`idPaciente`) REFERENCES `persona` (`idPersona`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `paciente`
--

LOCK TABLES `paciente` WRITE;
/*!40000 ALTER TABLE `paciente` DISABLE KEYS */;
INSERT INTO `paciente` VALUES (10,123,123,'2024-06-03 00:00:00','2024-06-20 00:00:00','EN TRATAMIENTO',12321232,12321232,NULL,NULL,'1',NULL,0,0,NULL,'hooa'),(11,123,123,'2024-06-02 00:00:00','2024-06-02 00:00:00','EN TRATAMIENTO',12321232,12321232,NULL,NULL,'1',NULL,0,0,NULL,'12321232'),(12,123,123,'2024-06-02 00:00:00','2024-06-02 00:00:00','EN TRATAMIENTO',12345678,12345678,NULL,NULL,'1',NULL,1,0,NULL,'123'),(13,123,123,'2024-06-02 00:00:00','2024-06-02 00:00:00','EN TRATAMIENTO',12345678,12345678,NULL,NULL,'1',NULL,0,0,NULL,'123'),(15,123,123,'2024-06-09 00:00:00','2024-06-09 00:00:00','FALLECIDO',69696969,69696969,NULL,NULL,'1',NULL,1,0,NULL,'calle coca'),(17,123,123,'2024-06-09 00:00:00','2024-06-09 00:00:00','EN TRATAMIENTO',12345678,12345678,NULL,NULL,'1',NULL,1,0,NULL,'123'),(19,123,123,'2024-06-11 00:00:00','2024-06-11 00:00:00','EN TRATAMIENTO',69306892,69306892,NULL,NULL,'1',NULL,0,0,NULL,'tiquipaya'),(20,123,123,'2024-06-11 00:00:00','2024-06-11 00:00:00','EN TRATAMIENTO',12345678,12345678,NULL,NULL,'1',NULL,1,0,NULL,'tiquipaya'),(21,123,123,'2024-06-12 00:00:00','2024-06-12 00:00:00','EN TRATAMIENTO',12345678,12345678,NULL,NULL,'1',NULL,0,0,NULL,'12345678'),(24,123,123,'2024-06-14 00:00:00','2024-06-14 00:00:00','EN TRATAMIENTO',71234567,71234567,NULL,NULL,'1',NULL,0,0,NULL,'tiquipaya'),(25,123,123,'2024-06-14 00:00:00','2024-06-14 00:00:00','EN TRATAMIENTO',69306892,69306892,NULL,NULL,'1',NULL,0,0,NULL,'tiquipaya'),(26,123,123,'2024-06-19 00:00:00','2024-06-19 00:00:00','EN TRATAMIENTO',87654321,87654321,NULL,NULL,'1',NULL,1,0,NULL,'ayacucho');
/*!40000 ALTER TABLE `paciente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `persona`
--

DROP TABLE IF EXISTS `persona`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `persona` (
  `idPersona` int NOT NULL AUTO_INCREMENT,
  `primerNombre` varchar(20) NOT NULL,
  `segundoNombre` varchar(20) DEFAULT NULL,
  `primerApellido` varchar(20) NOT NULL,
  `segundoApellido` varchar(20) DEFAULT NULL,
  `carnetIdentidad` varchar(10) NOT NULL,
  `numeroCelular` int NOT NULL,
  `usuario` varchar(30) NOT NULL,
  `contra` varchar(30) NOT NULL,
  `correo` varchar(100) NOT NULL,
  `estado` tinyint(1) NOT NULL DEFAULT '1',
  `fechaCreacion` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `fechaActualizacion` datetime DEFAULT NULL,
  `rol` varchar(20) NOT NULL COMMENT 'Roles: \n- ADMINISTRADOR\n- PERSONAL SALUD(DOCTOR)\n- PACIENTE',
  `primerInicioSesion` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`idPersona`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `persona`
--

LOCK TABLES `persona` WRITE;
/*!40000 ALTER TABLE `persona` DISABLE KEYS */;
INSERT INTO `persona` VALUES (1,'JOAQUIN','LEONARDO','CAMPOS','HERBAS','12345678',1234567,'admin','123','admin@gmail.com',1,'2024-05-20 14:19:42',NULL,'administrador',1),(2,'PABLO LUIS','DANIEL','CAMPOS','DALENCE','12345678',1234567,'doc','doc','dod@gmail.com',0,'2024-05-20 14:22:59','2024-06-11 22:16:04','doctor',1),(3,'LUIS','RODRIGO','HERBAS','PATANA','12345678',1234567,'doc2','doc1234','doc2@gmail.com',1,'2024-05-20 14:23:27',NULL,'doctor',0),(4,'VALERIA',NULL,'ROJAS',NULL,'12345678',1234567,'paciente1','123','paciente1@gmail.com',0,'2024-05-20 14:23:27',NULL,'paciente',1),(5,'LUIS','RODRIGO','HERBAS','PATANA','12345678',1234567,'doc2','doc1234','doc2@gmail.com',0,'2024-05-20 14:24:12','2024-06-12 08:43:01','doctor',0),(6,'VALERIA',NULL,'ROJAS',NULL,'12345678',1234567,'paciente1','123','paciente1@gmail.com',0,'2024-05-20 14:24:17',NULL,'paciente',1),(7,'JHON',NULL,'PARI',NULL,'12345678',1234567,'paciente2','123','paciente2@gmail.com',0,'2024-05-20 14:25:35',NULL,'paciente',1),(8,'VICTOR',NULL,'ECHEVERRIA',NULL,'12345678',1234567,'paciente3','fA7ansBb','paciente3@gmail.com',0,'2024-05-20 14:25:42',NULL,'paciente',0),(9,'victor','victor','victor','victor','123',123,'victor','UZTjzYjX','victor@gmail.com',0,'2024-06-02 19:19:52','2024-06-12 08:43:05','Doctor',0),(10,'victor','victor','victor','victor','123',12321232,'paciente','123','admin@gmail.com',0,'2024-06-02 21:08:07',NULL,'preregistrado',1),(11,'holamundo','holamundo','holamundo','holamundo','holamundo',12321232,'paciente','123','admin@gmail.com',0,'2024-06-02 21:11:13',NULL,'paciente',1),(12,'victor','victor','victor','victor','12345678',12345678,'paciente','123','admin@gmail.com',0,'2024-06-02 21:16:37',NULL,'paciente',1),(13,'victor','victor','victor','victor','12345678',12345678,'paciente','12345','admin@gmail.com',0,'2024-06-02 21:21:18',NULL,'paciente',1),(14,'victor','hugo','tapia','leon','123123123',123123123,'victor','ApEScNfr','victorhugotapia2000@gmail.com',0,'2024-06-08 22:56:10','2024-06-12 08:43:15','doctor',0),(15,'alfonso','muerto','quispe','huaca','69696969',69696969,'paciente','123','admin@gmail.com',1,'2024-06-09 18:13:56',NULL,'paciente',1),(16,'pepe','mesi','pablo','luis','123',76767676,'pepe','0tBIIYDW','vic@gmail.com',0,'2024-06-09 21:32:51','2024-06-12 08:43:22','doctor',0),(17,'juan','miguel','perez','mamani','12345678',12345678,'juan','123','mparisiles@gmail.com',1,'2024-06-09 23:00:11',NULL,'paciente',1),(18,'Jhon','Rodrigez','Tapia','Leon','12345678',69306892,'roly','SEk1FhAv','rolycg12@gmail.com',0,'2024-06-11 22:15:12','2024-06-12 08:43:29','doctor',0),(19,'victor','hugo','tapia','leon','18601812',69306892,'victor','YakDqdyP','victorhugotapialeon@gmail.com',1,'2024-06-11 22:19:16',NULL,'paciente',0),(20,'evo','evo','evo','evo','12345678',12345678,'evo','evo','mparisiles@gmail.com',0,'2024-06-11 23:19:23',NULL,'paciente',1),(21,'asd','asd','asd','asd','12345678',12345678,'jhon','pUI1ZPet','mparisiles@gmail.com',0,'2024-06-12 08:53:06',NULL,'preregistrado',0),(22,'gaston','k','silva','lopez','123123',71231233,'gsilvas','12345','gsilvas@univalle.edu',0,'2024-06-12 09:12:09','2024-06-23 20:47:51','doctor',1),(24,'jhon','arnold','pari','siles','12345678',71234567,'jhon','123','mparisiles@gmail.com',1,'2024-06-14 18:59:27',NULL,'paciente',1),(25,'hugo','franco','tapia','leon','10713789',69306892,'hugo','6KtYZLeV','mparisiles@gmail.com',1,'2024-06-14 19:16:33',NULL,'paciente',0),(26,'Sacha','Jhon','Rigel','Flores','87654321',87654321,'Sacha','0mNXzRbH','mparisiles@gmail.com',1,'2024-06-19 21:31:02',NULL,'preregistrado',0),(27,'Victor','Hugo','tapia','leon','12345678',78123456,'victor','sDrn3uxB','victorhugotapialeon2000@gmail.com',1,'2024-06-23 20:47:14',NULL,'doctor',0);
/*!40000 ALTER TABLE `persona` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `personalsalud`
--

DROP TABLE IF EXISTS `personalsalud`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `personalsalud` (
  `idPersonalSalud` int NOT NULL,
  `codigo` varchar(10) DEFAULT NULL,
  `Hospital_idHospital` int NOT NULL,
  KEY `fk_PersonalSalud_Persona1_idx` (`idPersonalSalud`),
  KEY `fk_PersonalSalud_Hospital1_idx` (`Hospital_idHospital`),
  CONSTRAINT `fk_PersonalSalud_Hospital1` FOREIGN KEY (`Hospital_idHospital`) REFERENCES `hospital` (`idHospital`),
  CONSTRAINT `fk_PersonalSalud_Persona1` FOREIGN KEY (`idPersonalSalud`) REFERENCES `persona` (`idPersona`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `personalsalud`
--

LOCK TABLES `personalsalud` WRITE;
/*!40000 ALTER TABLE `personalsalud` DISABLE KEYS */;
INSERT INTO `personalsalud` VALUES (2,'cdp1234',1),(3,'hpl1234',1),(8,'victor',1),(13,'qwe',1),(15,'dec',1),(17,'roly',1),(21,'abcde',1),(27,'asd',1);
/*!40000 ALTER TABLE `personalsalud` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `peso`
--

DROP TABLE IF EXISTS `peso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `peso` (
  `idPeso` int NOT NULL AUTO_INCREMENT,
  `fechaRegistro` datetime DEFAULT CURRENT_TIMESTAMP,
  `peso` tinyint DEFAULT NULL,
  `estado` tinyint(1) NOT NULL DEFAULT '1',
  `fechaCreacion` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `fechaActualizacion` datetime DEFAULT NULL,
  `Persona_idPersona` int NOT NULL,
  PRIMARY KEY (`idPeso`),
  KEY `fk_Peso_Persona1_idx` (`Persona_idPersona`),
  CONSTRAINT `fk_Peso_Persona1` FOREIGN KEY (`Persona_idPersona`) REFERENCES `persona` (`idPersona`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `peso`
--

LOCK TABLES `peso` WRITE;
/*!40000 ALTER TABLE `peso` DISABLE KEYS */;
INSERT INTO `peso` VALUES (1,'2024-06-08 23:09:30',123,1,'2024-06-08 23:09:30',NULL,4),(2,'2024-06-08 23:11:32',123,1,'2024-06-08 23:11:32',NULL,4),(3,'2024-06-09 17:35:03',1,1,'2024-06-09 17:35:03',NULL,4),(4,'2024-06-09 17:35:11',23,1,'2024-06-09 17:35:11',NULL,4),(5,'2024-06-09 17:35:17',15,1,'2024-06-09 17:35:17',NULL,4),(6,'2024-06-12 09:23:16',80,1,'2024-06-12 09:23:16',NULL,17),(7,'2024-06-12 09:23:21',80,1,'2024-06-12 09:23:21',NULL,17),(8,'2024-06-14 19:00:37',70,1,'2024-06-14 19:00:37',NULL,24),(9,'2024-06-14 19:17:25',75,1,'2024-06-14 19:17:25',NULL,24),(10,'2024-06-14 19:50:49',67,1,'2024-06-14 19:50:49',NULL,15),(11,'2024-06-20 09:12:52',58,1,'2024-06-20 09:12:52',NULL,24),(12,'2024-06-23 20:48:20',120,1,'2024-06-23 20:48:20',NULL,15),(13,'2024-06-24 09:19:15',50,1,'2024-06-24 09:19:15',NULL,24);
/*!40000 ALTER TABLE `peso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `region`
--

DROP TABLE IF EXISTS `region`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `region` (
  `idRegion` int NOT NULL AUTO_INCREMENT,
  `nombreRegion` varchar(40) NOT NULL,
  `estado` tinyint(1) NOT NULL DEFAULT '1',
  `fechaCreacion` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `fechaActualizacion` datetime DEFAULT NULL,
  PRIMARY KEY (`idRegion`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `region`
--

LOCK TABLES `region` WRITE;
/*!40000 ALTER TABLE `region` DISABLE KEYS */;
INSERT INTO `region` VALUES (1,'CBBA',1,'2024-05-21 17:55:04',NULL);
/*!40000 ALTER TABLE `region` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transferencia`
--

DROP TABLE IF EXISTS `transferencia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transferencia` (
  `idTransferencia` int NOT NULL AUTO_INCREMENT,
  `tipoTransferencia` varchar(45) NOT NULL,
  `sedeOrigen` varchar(45) NOT NULL,
  `establecimientoOrigen` varchar(45) NOT NULL,
  `cordinacionRedSaludOrigen` varchar(45) NOT NULL,
  `telefonoOrigen` varchar(45) NOT NULL,
  `fechaTransferencia` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `sedeDestino` varchar(45) NOT NULL,
  `establecimientoDestino` varchar(45) NOT NULL,
  `cordinacionRedSaludDestino` varchar(45) NOT NULL,
  `direccionDestino` varchar(45) NOT NULL,
  `numHistorialClinico` varchar(45) NOT NULL,
  `criterioIngreso` varchar(45) NOT NULL,
  `basiloscopiaDiagnostico` varchar(45) NOT NULL,
  `basiloscopiaResultado` varchar(45) NOT NULL,
  `basiloscopiaFecha` datetime NOT NULL,
  `cultivoDiagnostico` varchar(45) NOT NULL,
  `cultivoResultado` varchar(45) NOT NULL,
  `cultivoFecha` datetime NOT NULL,
  `genexpert` varchar(45) NOT NULL,
  `genexpertResultado` varchar(45) NOT NULL,
  `genexpertFecha` datetime NOT NULL,
  `pruebas` varchar(45) NOT NULL,
  `pruebasResultado` varchar(45) NOT NULL,
  `pruebasFecha` datetime NOT NULL,
  `ultimaBasiloscopia` varchar(45) NOT NULL,
  `ultimaBasiloscopiaResultado` varchar(45) NOT NULL,
  `ultimaBasiloscopiaFecha` datetime NOT NULL,
  `histopatologia` varchar(45) NOT NULL,
  `histopatologiaResulto` varchar(45) NOT NULL,
  `histopatologiaFecha` datetime NOT NULL,
  `motivo` varchar(45) NOT NULL,
  `tratamiento` varchar(45) NOT NULL,
  `fase` varchar(45) NOT NULL,
  `mes` varchar(45) NOT NULL,
  `dosis` varchar(45) NOT NULL,
  `comentario` varchar(45) NOT NULL,
  `idDoctor` int NOT NULL,
  `cargo` varchar(45) NOT NULL,
  `estado` tinyint(1) NOT NULL DEFAULT '1',
  `fechaCreacion` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `fechaActualizacion` datetime DEFAULT NULL,
  `persona_idPersona` int NOT NULL,
  PRIMARY KEY (`idTransferencia`),
  KEY `fk_Transferencia_persona1_idx` (`persona_idPersona`),
  CONSTRAINT `fk_Transferencia_persona1` FOREIGN KEY (`persona_idPersona`) REFERENCES `persona` (`idPersona`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transferencia`
--

LOCK TABLES `transferencia` WRITE;
/*!40000 ALTER TABLE `transferencia` DISABLE KEYS */;
INSERT INTO `transferencia` VALUES (1,'Referencia','123','123','123','123','2024-06-09 00:00:00','123','123','123','123','123','Pulmonar Bacteriológicamente Positivo','123','123','2024-06-09 00:00:00','123','123','2024-06-09 00:00:00','123','123','2024-06-09 00:00:00','213','123','2024-06-09 00:00:00','213','123','2024-06-09 00:00:00','123','123','2024-06-09 00:00:00','123','TB-MDR','Intensiva','123','123','123',1,'123',1,'2024-06-09 18:45:33',NULL,15),(2,'Referencia','123','123','123','123','2024-06-09 00:00:00','123','123','123','123','123','Pulmonar Bacteriológicamente Positivo','123','123','2024-06-09 00:00:00','123','123','2024-06-09 00:00:00','123','123','2024-06-09 00:00:00','213','123','2024-06-09 00:00:00','213','123','2024-06-09 00:00:00','123','123','2024-06-09 00:00:00','123','TB-MDR','Intensiva','123','123','',1,'123',1,'2024-06-09 18:46:30',NULL,15),(3,'ContraReferencia','1','1','1','1','2024-06-19 00:00:00','1','1','1','1','1','Perdida en el seguimiento','1','1','2024-06-19 00:00:00','1','1','2024-06-19 00:00:00','1','1','2024-06-19 00:00:00','1','1','2024-06-19 00:00:00','1','1','2024-06-19 00:00:00','1','1','2024-06-19 00:00:00','1','TB-MDR','Intensiva','1','1','1',1,'1',1,'2024-06-19 21:33:27',NULL,15);
/*!40000 ALTER TABLE `transferencia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `verificacion_tb`
--

DROP TABLE IF EXISTS `verificacion_tb`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `verificacion_tb` (
  `idverificacion_tb` int NOT NULL AUTO_INCREMENT,
  `numeroVerificacion` tinyint DEFAULT NULL,
  `fechaVerificacion` datetime DEFAULT NULL,
  `tipo` varchar(20) DEFAULT NULL COMMENT 'Este campo puede ser:\n- Baciloscopia\n- Cultivo',
  `estado` tinyint(1) NOT NULL DEFAULT '1',
  `fechaCreacion` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `fechaActualizacion` datetime DEFAULT NULL,
  `idPersona` int NOT NULL,
  PRIMARY KEY (`idverificacion_tb`),
  KEY `fk_verificacion_tb_Persona1_idx` (`idPersona`),
  CONSTRAINT `fk_verificacion_tb_Persona1` FOREIGN KEY (`idPersona`) REFERENCES `persona` (`idPersona`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `verificacion_tb`
--

LOCK TABLES `verificacion_tb` WRITE;
/*!40000 ALTER TABLE `verificacion_tb` DISABLE KEYS */;
/*!40000 ALTER TABLE `verificacion_tb` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-06-25 12:02:32
