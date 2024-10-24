-- SQLite Script
-- Converted from MySQL Workbench

-- Create users table
CREATE TABLE IF NOT EXISTS users (
    email TEXT PRIMARY KEY,
    password VARCHAR(16) NOT NULL,
    role VARCHAR(16),
    compliance INTEGER NOT NULL DEFAULT 1
);

-- Create zones table
CREATE TABLE IF NOT EXISTS zones (
    zone_id INTEGER PRIMARY KEY AUTOINCREMENT,
    zone_name VARCHAR(255) UNIQUE,
    zone_description TEXT
);

-- Create zone_points table
CREATE TABLE IF NOT EXISTS zone_points (
                point_id INTEGER PRIMARY KEY AUTOINCREMENT,
                zone_id INTEGER NOT NULL,
                latitude DECIMAL(10,6) NOT NULL,
                longitude DECIMAL(10,6) NOT NULL,
                FOREIGN KEY (zone_id) REFERENCES zones(zone_id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Create restrictions table
CREATE TABLE IF NOT EXISTS restrictions (
    restriction_id INTEGER PRIMARY KEY AUTOINCREMENT,
    restriction_type VARCHAR(255),
    restriction_description TEXT,
    zone_id INTEGER NOT NULL,
    FOREIGN KEY (zone_id) REFERENCES zones(zone_id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Create trips table
CREATE TABLE IF NOT EXISTS trips (
    trip_id INTEGER PRIMARY KEY AUTOINCREMENT,
    email TEXT NOT NULL,
    zone_id INTEGER NOT NULL,
    trip_description TEXT,
    timestamp DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (email) REFERENCES users(email) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (zone_id) REFERENCES zones(zone_id) ON DELETE NO ACTION ON UPDATE CASCADE
);
CREATE TABLE "questions" (
	"idQuestions"	INTEGER,
	"question"	TEXT NOT NULL,
	"option1"	TEXT NOT NULL,
	"option2"	TEXT NOT NULL,
	"option3"	TEXT NOT NULL,
	"correctOption"	INTEGER NOT NULL,
	PRIMARY KEY("idQuestions" AUTOINCREMENT)
)
