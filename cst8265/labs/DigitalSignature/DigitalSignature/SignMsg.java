import java.io.*;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.security.*;

public class SignMsg {
	public static void main(String[] args) {
        try {
            // Get instance and initialize a KeyPairGenerator object.
            KeyPairGenerator keyGen = KeyPairGenerator.getInstance("DSA", "SUN");
            SecureRandom random = SecureRandom.getInstance("SHA1PRNG", "SUN");
            keyGen.initialize(1024, random);

            // Get a PrivateKey from the generated key pair.
            KeyPair keyPair = keyGen.generateKeyPair();
            PrivateKey privateKey = keyPair.getPrivate();

            // Get an instance of Signature object and initialize it.
            Signature signature = Signature.getInstance("SHA1withDSA", "SUN");
            signature.initSign(privateKey);

            // Read the data to be signed to the Signature object
            byte[] bytes = Files.readAllBytes(Paths.get("data"));

	    // using the update() method and generate the digital signature.
            signature.update(bytes);
            byte[] digitalSignature = signature.sign();

            // Save digital signature and the public key to a file so that receiver can read verify the signature it.
            Files.write(Paths.get("signature"), digitalSignature);
            Files.write(Paths.get("publickey"), keyPair.getPublic().getEncoded());
        } catch (Exception e) {
            e.printStackTrace();
        }

	String msg = reader();
        System.out.println(msg);
       System.out.println("This message is digitally signed!!");
      
   }//main
	public static String reader() {
	String msg = "";	
	// The name of the file to open.
	String fileName = "data";
	// This will reference one line at a time
	String line = null;
	try {
		BufferedReader bufferedReader = new BufferedReader(
				new FileReader(new File(fileName)));
		while((line = bufferedReader.readLine()) != null) {
			//System.out.println(line);
			msg = msg + "\n" + line;
		}   	
		// Always close files.
		bufferedReader.close();  
	}
	catch(FileNotFoundException ex) {
		System.out.println("Unable to open file " +	fileName);                
	}
	catch(IOException ex) {
		System.out.println("Error reading file"+ fileName);                  
	}
	return msg;
 }
      
}//class