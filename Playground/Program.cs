using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

public class Test
{
    public static void Main()
    {




        OuterObject outer = new OuterObject()
        {
            OuterVariable = 123,
            MyObjects = new System.Collections.ObjectModel.Collection<MyObject>()
            {
                { new MyObject() { n1 = 500 } },
                { new MyObject() { n1 = 700 } }
            }
        };

        // Create a new TestSimpleObject object.
        MyObject obj = new MyObject() { n1 = 23, n2 = 5445};

        Console.WriteLine("\n Before serialization the object contains: ");
    

        // Open a file and serialize the object into binary format.
        Stream stream = File.Open("DataFile.dat", FileMode.Create);
        BinaryFormatter formatter = new BinaryFormatter();


        var serr = "";
        var serializer = new XmlSerializer(typeof(OuterObject));
        using (var textWriter = new StringWriter())
        {
            serializer.Serialize(textWriter, outer);
            serr = textWriter.ToString();

            //var res = (MyObject)serializer.Deserialize(g);
        }

        using (var stringReader = new StringReader(serr))
        {
            var res = (OuterObject)serializer.Deserialize(stringReader);
        }


            try
            {
                formatter.Serialize(stream, obj);

                // Print the object again to see the effect of the 
                //OnSerializedAttribute.
                Console.WriteLine("\n After serialization the object contains: ");

                // Set the original variable to null.
                obj = null;
                stream.Close();

                // Open the file "DataFile.dat" and deserialize the object from it.
                stream = File.Open("DataFile.dat", FileMode.Open);

                // Deserialize the object from the data file.
                obj = (MyObject)formatter.Deserialize(stream);

                Console.WriteLine("\n After deserialization the object contains: ");

                Console.ReadLine();
            }
            catch (SerializationException se)
            {
                Console.WriteLine("Failed to serialize. Reason: " + se.Message);
                throw;
            }
            catch (Exception exc)
            {
                Console.WriteLine("An exception occurred. Reason: " + exc.Message);
                throw;
            }
            finally
            {
                stream.Close();
                obj = null;
                formatter = null;
            }
    }
}

// This is the object that will be serialized and deserialized.
[Serializable()]
public class TestSimpleObject
{
    // This member is serialized and deserialized with no change.
    public int member1;

    // The value of this field is set and reset during and 
    // after serialization.
    private string member2;

    // This field is not serialized. The OnDeserializedAttribute 
    // is used to set the member value after serialization.
    [NonSerialized()]
    public string member3;

    // This field is set to null, but populated after deserialization.
    private string member4;

    // Constructor for the class.
    public TestSimpleObject()
    {
        member1 = 11;
        member2 = "Hello World!";
        member3 = "This is a nonserialized value";
        member4 = null;
    }

    public void Print()
    {
        Console.WriteLine("member1 = '{0}'", member1);
        Console.WriteLine("member2 = '{0}'", member2);
        Console.WriteLine("member3 = '{0}'", member3);
        Console.WriteLine("member4 = '{0}'", member4);
    }

    [OnSerializing()]
    internal void OnSerializingMethod(StreamingContext context)
    {
        member2 = "This value went into the data file during serialization.";
    }

    [OnSerialized()]
    internal void OnSerializedMethod(StreamingContext context)
    {
        member2 = "This value was reset after serialization.";
    }

    [OnDeserializing()]
    internal void OnDeserializingMethod(StreamingContext context)
    {
        member3 = "This value was set during deserialization";
    }

    [OnDeserialized()]
    internal void OnDeserializedMethod(StreamingContext context)
    {
        member4 = "This value was set after deserialization.";
    }
}

// Output:
//  Before serialization the object contains: 
// member1 = '11'
// member2 = 'Hello World!'
// member3 = 'This is a nonserialized value'
// member4 = ''
//
//  After serialization the object contains: 
// member1 = '11'
// member2 = 'This value was reset after serialization.'
// member3 = 'This is a nonserialized value'
// member4 = ''
//
//  After deserialization the object contains: 
// member1 = '11'
// member2 = 'This value went into the data file during serialization.'
// member3 = 'This value was set during deserialization'
// member4 = 'This value was set after deserialization.'