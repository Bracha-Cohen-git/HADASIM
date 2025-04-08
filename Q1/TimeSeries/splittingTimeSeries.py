
import pandas as pd
import os

# Helper function for Exercise 4 - Adjusting the code to support the new format
def load_data_dynamic(input_file):
    try:
        if input_file.endswith(".csv"):
            df = pd.read_csv(input_file, parse_dates=["timestamp"], dayfirst=True)
        elif input_file.endswith(".parquet"):
            df = pd.read_parquet(input_file)
            df["timestamp"] = pd.to_datetime(df["timestamp"], format="%d/%m/%Y %H:%M", errors="coerce")
        else:
            print(f"Unsupported file format: {input_file}")
            return None
        return df
    except Exception as e:
        print(f"Error loading file {input_file}: {e}")
        return None


#Function to split a file into small files
def split_time_series_by_day(input_file, output_folder):
    os.makedirs(output_folder, exist_ok=True)
    # Reading the data
    df = pd.read_csv(input_file, parse_dates=["timestamp"], dayfirst=True)
    '''
    Exercise 4 - To support the new format I will add a function def load_data_dynamic(input_file) that will detect if the input is CSV or Parquet, and load the file accordingly.
    And I will add a check here whether the file was loaded successfully and I will continue the process, or stop
    df = load_data_dynamic(input_file)
    if df is None:
    return
    '''
    df["date"] = df["timestamp"].dt.date

    for date, group in df.groupby("date"):
        output_path = os.path.join(output_folder, f"time_series_{date}.csv")
        group.drop(columns=["date"], inplace=True)
        group.to_csv(output_path, index=False)
    print(f"30 daily files saved successfully")


# Function to calculate hourly average
def calc_hourly_avg(input_folder, output_folder):
    os.makedirs(output_folder, exist_ok=True)
    results = []

    for file in os.listdir(input_folder):
        if file.endswith(".csv"):
            file_path = os.path.join(input_folder, file)
            df = pd.read_csv(file_path, parse_dates=["timestamp"])

            # Convert timestamp to datetime format
            df["timestamp"] = pd.to_datetime(df["timestamp"], errors="coerce")
            # Remove duplicates
            df.drop_duplicates(subset=["timestamp"], keep="first", inplace=True)
            # remove rows with missing/incorrect values in the 'value' column
            df["value"] = pd.to_numeric(df["value"], errors='coerce')
            df.dropna(subset=["value", "timestamp"], inplace=True)

            # Round timestamps to the nearest hour down
            df["hour"] = df["timestamp"].dt.floor("h")
            # Calculate hourly average
            hourly_avg = df.groupby("hour")["value"].mean().reset_index()
            hourly_avg.columns = ["start_time", "average_value"]

            output_path = os.path.join(output_folder, f"hourly_avg_{file}")
            hourly_avg.to_csv(output_path, index=False)

            # Save to list for later consolidation
            results.append(hourly_avg)

    print(f"30 average files saved successfully")
    return results

# Function to combine averages of all files
def merge_hourly_avg(input_folder, output_file):
    all_files = [os.path.join(input_folder, f) for f in os.listdir(input_folder) if f.startswith("hourly_avg")]
    df_list = [pd.read_csv(f, parse_dates=["start_time"]) for f in all_files]

    # Combining all data into one file
    final_df = pd.concat(df_list).sort_values("start_time")
    final_df.to_csv(output_file, index=False)
    print(f"Final average file saved: {output_file}")


def main():
    input_file = "time_series.csv"
    '''
    Exercise 4 - Adjusting input_file according to the input file format --> "time_series.csv"/"time_series.parquet"
    '''
    output_folder="split_files"
    split_time_series_by_day(input_file, output_folder)
    hourly_avg = calc_hourly_avg("split_files", "hourly_avg_files")
    merge_hourly_avg("hourly_avg_files", "all_hourly_avg.csv")


if __name__ == "__main__":
    main()

