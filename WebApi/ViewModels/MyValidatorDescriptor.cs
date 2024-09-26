public class MyValidatorDescriptor
{
    private Dictionary<string, object> metadata;

    public MyValidatorDescriptor() {
        metadata = new Dictionary<string, object>();
    }

    public void AddMetadata(string key, object value) {
        metadata[key] = value;
    }

    public object GetMetadata(string key) {
        if (metadata.ContainsKey(key)) {
            return metadata[key];
        }
        return null;
    }
}
