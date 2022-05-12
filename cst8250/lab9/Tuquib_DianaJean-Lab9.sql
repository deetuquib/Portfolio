USE SAKILA;
SELECT * FROM film;

# 1. Alter the table film by adding the following column and write the query to do so as your answer: urlsafe VARCHAR(255) (1 mark)
	ALTER TABLE film ADD COLUMN urlsafe VARCHAR(255);


# 2. Create a user defined function, named clean_string, to strip out spaces. The user defined function will accept a string(varchar) as an argument.   (4 marks)
	DELIMITER $$
	CREATE FUNCTION clean_string(old_str VARCHAR(255) )
	RETURNS VARCHAR(255)
	DETERMINISTIC
	BEGIN
		DECLARE new_str VARCHAR(255);
		SET new_str = REPLACE(old_str,' ','');
		RETURN new_str;
	END $$
	DELIMITER ;


# 3. Test your function by running and copy the result of running this as your answer: (1 mark)
	SELECT clean_string(" this is a test");
    # result: thisisatest


# 4. Test your function by running a string through that has other characters present such as a period or a semi colon. (1 mark)
	SELECT clean_string("hello world!");
    # result: helloworld!

# 5. Alter your function to strip out the following characters in addition to spaces: .;!@#$%* (2 marks)
    DROP FUNCTION clean_string;
    DELIMITER $$
    CREATE FUNCTION clean_string(old_str VARCHAR(255) )
    RETURNS VARCHAR(255)
    DETERMINISTIC
    BEGIN
        DECLARE new_str VARCHAR(255);
        SET new_str = REPLACE(
            REPLACE(
                REPLACE(
                    REPLACE(
                        REPLACE(
                            REPLACE(
                                REPLACE(
                                    REPLACE(
                                        REPLACE(
                                            REPLACE(
                                                REPLACE(
                                                    REPLACE(
                                                        REPLACE(
                                                            REPLACE(
                                                                REPLACE(
                                                                    REPLACE(
                                                                        REPLACE(
                                                                            REPLACE(
                                                                                REPLACE(
                                                                                    REPLACE(
                                                                                        REPLACE(
                                                                                            REPLACE(
                                                                                                old_str,
                                                                                                ' ',''),
                                                                                            '.',''),
                                                                                        ';',''),
                                                                                    '!',''),
                                                                                '@',''),
                                                                            '#',''),
                                                                        '$',''),
                                                                    '%',''),
                                                                '*',''),
                                                            '~',''),
                                                        '?',''),
                                                    '+',''),
                                                '-',''),
                                            '<',''),
                                        '>',''),
                                    '=',''),
                                '|',''),
                            '{',''),
                        '}',''),
                    '[',''),
                ']',''),
            '\n','');
        RETURN new_str;
    END $$
    DELIMITER ;

# 6. Now run your function against the description field of the film table for the first 5 rows and copy the result as your answer. (1 mark)
    SELECT clean_string(description) FROM film LIMIT 5;
#     Results:
#     AEpicDramaofaFeministAndaMadScientistwhomustBattleaTeacherinTheCanadianRockies
#     AAstoundingEpistleofaDatabaseAdministratorAndaExplorerwhomustFindaCarinAncientChina
#     AAstoundingReflectionofaLumberjackAndaCarwhomustSinkaLumberjackinABaloonFactory
#     AFancifulDocumentaryofaFrisbeeAndaLumberjackwhomustChaseaMonkeyinASharkTank
#     AFastPacedDocumentaryofaPastryChefAndaDentistwhomustPursueaForensicPsychologistinTheGulfofMexico