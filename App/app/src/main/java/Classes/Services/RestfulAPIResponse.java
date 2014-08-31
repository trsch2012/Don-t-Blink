package Classes.Services;

/**
 * Created by Todd on 7/12/2014.
 */
public class RestfulAPIResponse<T> {
    public boolean success;
    public String errorMessage;
    public T result;

    public RestfulAPIResponse(boolean success, String errorMessage, T result){
        this.success = success;
        this.errorMessage = errorMessage;
        this.result = result;
    }
}
