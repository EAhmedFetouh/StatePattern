
namespace StatePattern
{
    public class Document
    {
        public string State { get; private set; }

        public Document()
        {
            State = "Draft";
        }

        public void ResetToDraft()
        {
            State = "Draft";
            Console.WriteLine("🔄 Reset to Draft.");
        }


        public void Expire()
        {
            if (State == "UnderReview" || State == "NeedsRevision")
            {
                State = "Expired";
                Console.WriteLine("⏰ The document has expired.");
            }
            else
            {
                Console.WriteLine("❌ Cannot expire in the current state.");
            }
        }


        public void Edit()
        {
            if (State == "Draft" || State == "NeedsRevision")
            {
                Console.WriteLine("✏️ Editing the document...");
            }
            else if (State == "UnderReview")
            {
                Console.WriteLine("❌ You cannot edit while under review.");
            }
            else if (State == "Published")
            {
                Console.WriteLine("❌ You cannot edit a published document.");
            }
            else if (State == "Rejected")
            {
                Console.WriteLine("❌ You cannot edit a rejected document.");
            }

            else if (State == "Expired")
            {
                Console.WriteLine("❌ You Cannot Edit an expired document.");
            }
            else
            {
                Console.WriteLine("⚠️ Unknown state. No action performed.");
            }
        }

        public void Submit()
        {
            if (State == "Draft")
            {
                Console.WriteLine("📤 Submitted for review.");
                State = "UnderReview";
            }
            else if (State == "NeedsRevision")
            {
                Console.WriteLine("📤 Resubmitted for review.");
                State = "UnderReview";
            }
            else if (State == "UnderReview")
            {
                Console.WriteLine("❌ Already under review.");
            }
            else if (State == "Published")
            {
                Console.WriteLine("❌ Cannot submit after publishing.");
            }
            else if (State == "Rejected")
            {
                Console.WriteLine("❌ Cannot submit a rejected document. Reset to Draft first.");
            }
            else if (State == "Expired")
            {
                Console.WriteLine("❌ Cannot reject an expired document.");
            }
            else
            {
                Console.WriteLine("⚠️ Unknown state. No action performed.");
            }
        }

        public void Publish()
        {
            if (State == "UnderReview")
            {
                Console.WriteLine("✅ Published.");
                State = "Published";
            }
            else if (State == "Draft")
            {
                Console.WriteLine("❌ Cannot publish directly from Draft.");
            }
            else if (State == "NeedsRevision")
            {
                Console.WriteLine("❌ Cannot publish while it needs revision.");
            }
            else if (State == "Published")
            {
                Console.WriteLine("ℹ️ Already published.");
            }
            else if (State == "Rejected")
            {
                Console.WriteLine("❌ Cannot publish a rejected document.");
            }

            else
            {
                Console.WriteLine("⚠️ Unknown state. No action performed.");
            }
        }

        public void Reject()
        {
            if (State == "UnderReview")
            {
                Console.WriteLine("🤔 Choose rejection type:");
                Console.WriteLine("1) Final Reject");
                Console.WriteLine("2) Needs Revision");
                Console.Write("> ");
                var choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine("❌ Document permanently rejected.");
                    State = "Rejected";
                }
                else if (choice == "2")
                {
                    Console.WriteLine("🔁 Document needs revision.");
                    State = "NeedsRevision";
                }
                else
                {
                    Console.WriteLine("⚠️ Invalid choice. No change.");
                }
            }
            else if (State == "Draft")
            {
                Console.WriteLine("❌ Cannot reject while in Draft.");
            }
            else if (State == "NeedsRevision")
            {
                Console.WriteLine("❌ Already needs revision. Submit again when ready.");
            }
            else if (State == "Published")
            {
                Console.WriteLine("❌ Cannot reject a published document.");
            }
            else if (State == "Rejected")
            {
                Console.WriteLine("ℹ️ Already rejected.");
            }

            else
            {
                Console.WriteLine("⚠️ Unknown state. No action performed.");
            }
        }
    }
}
