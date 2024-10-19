# Define the Comment class
class Comment:
    def __init__(self, commenter_name, comment_text):
        self.commenter_name = commenter_name
        self.comment_text = comment_text

# Define the Video class
class Video:
    def __init__(self, title, author, length):
        self.title = title
        self.author = author
        self.length = length
        self.comments = []

    # Method to add comments to the video
    def add_comment(self, comment):
        self.comments.append(comment)

    # Method to get the number of comments on the video
    def get_number_of_comments(self):
        return len(self.comments)

    # Method to display the video details along with the comments
    def display_video_info(self):
        print(f"Title: {self.title}")
        print(f"Author: {self.author}")
        print(f"Length: {self.length} minutes")
        print(f"Number of Comments: {self.get_number_of_comments()}")
        print("Comments:")
        for comment in self.comments:
            print(f"- {comment.commenter_name}: {comment.comment_text}")

# Main program to create videos and comments
def main():
    # Create 3 Video objects
    video1 = Video("Python Basics", "John Doe", 10)
    video2 = Video("Advanced Python", "Jane Smith", 15)
    video3 = Video("Python OOP", "Alice Johnson", 12)

    # Create comments for each video
    comment1_v1 = Comment("User1", "Great video, very helpful!")
    comment2_v1 = Comment("User2", "Clear explanation, thanks!")
    comment3_v1 = Comment("User3", "I learned a lot from this.")

    comment1_v2 = Comment("User4", "I was confused at first, but now I get it.")
    comment2_v2 = Comment("User5", "Very detailed, great work!")
    comment3_v2 = Comment("User6", "Good pacing and examples.")

    comment1_v3 = Comment("User7", "OOP is always tricky, but this helped.")
    comment2_v3 = Comment("User8", "Well done, I understand classes now.")
    comment3_v3 = Comment("User9", "Thanks for the clear explanation!")

    # Add comments to video1
    video1.add_comment(comment1_v1)
    video1.add_comment(comment2_v1)
    video1.add_comment(comment3_v1)

    # Add comments to video2
    video2.add_comment(comment1_v2)
    video2.add_comment(comment2_v2)
    video2.add_comment(comment3_v2)

    # Add comments to video3
    video3.add_comment(comment1_v3)
    video3.add_comment(comment2_v3)
    video3.add_comment(comment3_v3)

    # Store the video objects in a list
    videos = [video1, video2, video3]

    # Display information for each video
    for video in videos:
        video.display_video_info()
        print()  # Print an empty line between video information for better readability

# Run the main program
if __name__ == "__main__":
    main()
