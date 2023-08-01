import javax.crypto.Cipher;
import javax.crypto.spec.SecretKeySpec;

public class AES {

    private byte[] key = "12345678abcdefgh".getBytes();// This is your key

    public byte[] encrypt(byte[] plainText) throws Exception {
        // Put your code here
        SecretKeySpec secretKey = new SecretKeySpec(key, "AES");
        Cipher cipher = Cipher.getInstance("AES/ECB/PKCS5Padding");
        cipher.init(Cipher.ENCRYPT_MODE, secretKey);
        return cipher.doFinal(plainText);
        // return plainText;
    }

    /**
     * Decrypts the given byte array
     * cipherText The data to decrypt
     */
    public byte[] decrypt(byte[] cipherText) throws Exception {
        // put your code here
        SecretKeySpec secretKey = new SecretKeySpec(key, "AES");
        Cipher cipher = Cipher.getInstance("AES/ECB/PKCS5Padding");
        cipher.init(Cipher.DECRYPT_MODE, secretKey);
        return cipher.doFinal(cipherText);
        // return cipherText;
    }

}
