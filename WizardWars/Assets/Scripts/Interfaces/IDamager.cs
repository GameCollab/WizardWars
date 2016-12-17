using System;

public interface IDamager<T> {
    void Damage<T>(T amount);
}
