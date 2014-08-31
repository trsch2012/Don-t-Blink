package Classes.Services;

import java.lang.reflect.ParameterizedType;

/**
 * Created by Todd on 7/12/2014.
 */
public class Container<T> {
    public Class<T> getContents(){
       Class<T> t = (Class<T>) getClass().getGenericSuperclass().getClass();
        return t;
        //return (Class<T>) ((ParameterizedType) getClass().getGenericSuperclass()).getActualTypeArguments()[0];
    }
}
