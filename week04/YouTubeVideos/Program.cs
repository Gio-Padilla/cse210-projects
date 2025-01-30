using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        // Creating the video list
        List<Video> videoList = new List<Video>();

        // Add videos directly to the list
        videoList.Add(new Video("How to dance", "John", 1025));
        videoList.Add(new Video("Jumping over the moon", "Alex", 312));
        videoList.Add(new Video("Fixing a phone", "Cory", 417));
        videoList.Add(new Video("My fastest speed", "Tom", 1542));

        // Add comments to the videos
        videoList[0].AddComment(new Comment("Alice", "Great tutorial!"));
        videoList[0].AddComment(new Comment("Bob", "I learned a lot, thanks!"));
        videoList[0].AddComment(new Comment("Charlie", "Could you do a follow-up on advanced moves?"));
        videoList[0].AddComment(new Comment("Diana", "Amazing energy!"));

        videoList[1].AddComment(new Comment("Eve", "I can't believe you actually did it!"));
        videoList[1].AddComment(new Comment("Frank", "This was so entertaining!"));
        videoList[1].AddComment(new Comment("Grace", "How many tries did it take?"));
        videoList[1].AddComment(new Comment("Hank", "Truly inspiring!"));

        videoList[2].AddComment(new Comment("Ivy", "This saved me a trip to the repair shop!"));
        videoList[2].AddComment(new Comment("Jack", "Clear and concise instructions."));
        videoList[2].AddComment(new Comment("Karen", "Can you show how to fix a broken screen?"));
        videoList[2].AddComment(new Comment("Leo", "Worked perfectly, thank you!"));

        videoList[3].AddComment(new Comment("Mia", "Incredible speed!"));
        videoList[3].AddComment(new Comment("Nina", "How did you train for this?"));
        videoList[3].AddComment(new Comment("Oscar", "Absolutely amazing performance."));
        videoList[3].AddComment(new Comment("Paul", "You should enter a competition!"));

        foreach (Video video in videoList)
        {
            Console.WriteLine($"TITLE: {video.GetTitle()}");
            Console.WriteLine($"AUTHOR: {video.GetAuthor()}");
            Console.WriteLine($"LENGTH: {video.GetLength()} Seconds");
            Console.WriteLine($"NUMBER OF COMMENTS: {video.NumberOfComments()}");
            Console.WriteLine("ALL COMMENTS FROM VIDEO:");
            video.DisplayAllComments();
            Console.WriteLine();
        }
    }
}