public class BaseException
{
    public bool Toggle { get; private set; }
    private bool _defaultToggle;

    public BaseException(bool defaultToggle)
    {
        _defaultToggle = defaultToggle;
        Toggle = _defaultToggle;
    }

    public void FlipToggle()
    {
        Toggle = !_defaultToggle;
    }
}
