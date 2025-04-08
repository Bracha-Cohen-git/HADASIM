
from collections import Counter
import os
import re

#Task 1
#Function to split the logs.txt file into smaller parts
def file_splitting(input_file, num_of_lines):
    with open(input_file, 'r', encoding='utf-8') as file:
        file_num=0
        lines=[]
        for i, line in enumerate(file):
            lines.append(line)
            if (i+1) % num_of_lines==0:
                with open(f'logs_{file_num}.txt', 'w', encoding='utf-8') as output_file:
                    output_file.writelines(lines)
                lines=[]
                file_num+=1

        if lines: # Save the last part if there are any leftovers
            with open(f'logs_{file_num}.txt', 'w', encoding='utf-8') as output_file:
                output_file.writelines(lines)


#Task 2
#Function to count the frequency of each error code for each part
def count_file_errors(file_path):
    error_count=Counter()

    with open(file_path, 'r', encoding='utf-8') as file:
        for line in file:
            error_code=re.search(r'Error: (\w+_\d+)', line).group(1)
            if error_code:
                error_count[error_code] += 1

    return error_count


# Task 3
#Function to add the frequency counts from all parts
def count_all_files_errors(folder):
    final_counter = Counter()
    for file_name in os.listdir(folder):
        if file_name.startswith("logs_") and file_name.endswith(".txt"):
            file_path = os.path.join(folder, file_name)
            file_errors = count_file_errors(file_path)
            final_counter.update(file_errors)

    return final_counter


def main():
    input_file = "logs.txt"
    num_of_lines=50000
    file_splitting(input_file, num_of_lines)

    while True:
        try:
            N = int(input("Enter the number of most common error codes to display: "))
            if N > 0:
                break
            else:
                print("Please enter a positive integer.")
        except ValueError:
            print("Invalid input. Please enter a positive integer.")

    folder = r"C:\Users\1\Documents\PyCharm\Logs"
    total_errors = count_all_files_errors(folder)

    # Task 4
    #Finding the N most common error codes from the merged counts
    for error, count in total_errors.most_common(N):
        print(f"Error: {error} - {count} times")


if __name__ == "__main__":
    main()






