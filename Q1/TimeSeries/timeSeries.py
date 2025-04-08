
import pandas as pd

# Function to read data
def load_data(input_file):
    try:
        df = pd.read_csv(input_file)
        print(f"File {input_file} uploaded successfully")
        return df
    except Exception as e:
        print(f"Error loading file: {e}")
        return None


# Function to convert timestamp to datetime format
def convert_timestamp(df):
    try:
        df["timestamp"] = pd.to_datetime(df["timestamp"], format="%d/%m/%Y %H:%M", errors="coerce")

        if df["timestamp"].isnull().sum() > 0:
            print("Invalid timestamps found")
            return False
        print("The time stamps are correct")
        return True
    except Exception as e:
        print(f"Error converting timestamp: {e}")
        return False


# Function to remove duplicates
def remove_duplicates(df):
    num_duplicates = df.duplicated(subset=["timestamp"]).sum()

    df_without_duplicates = df.drop_duplicates(subset=["timestamp"], keep="first")
    if num_duplicates > 0:
        print(f"Removed {num_duplicates} rows with duplicate timestamp")
    else:
        print("No duplicates found by timestamp")
    return df_without_duplicates



# Function to remove rows with missing/incorrect values in the 'value' column
def fix_value_column(df):
    num_missing = df["value"].isnull().sum()
    num_non_numeric = df[~df["value"].astype(str).str.replace('.', '', 1).str.isnumeric()].shape[0]

    # Delete rows with missing values
    df_without_missing_values = df.dropna(subset=["value"])

    # Convert the column to float type to ensure all values are numeric
    df_without_missing_values.loc[:, "value"] = pd.to_numeric(df_without_missing_values["value"], errors="coerce")

    # Delete rows where the value was not numeric
    df_without_missing_values = df_without_missing_values.dropna(subset=["value"])

    total_removed = num_missing + num_non_numeric
    if total_removed > 0:
        print(f"{total_removed} rows with missing/invalid values in the 'value' column were removed")
    else:
        print("All values in the 'value' column are correct")

    return df_without_missing_values



# Function to save the processed data to a new file
def save_data(df, output_file):
    try:
        df.to_csv(output_file, index=False)
        print(f"The data was successfully saved to file: {output_file}")
    except Exception as e:
        print(f"Error saving data: {e}")


# Function to calculate hourly average
def calc_hourly_avg(df):
    try:
        df["timestamp"] = pd.to_datetime(df["timestamp"], errors="coerce")
        # Round timestamps to the nearest hour down
        df["hour"] = df["timestamp"].dt.floor("h")
        hourly_avg = df.groupby("hour")["value"].mean().reset_index()
        hourly_avg.columns = ["start_time", "average_value"]
        print("Hourly average calculation successfully completed")
        return hourly_avg
    except Exception as e:
        print(f"Error in calculating hourly average: {e}")
        return None



def main():
    # ---Part A---
    input_file = "time_series.csv"
    df = load_data(input_file)
    if df is None:
        return  #Stop in case of loading error
    if not convert_timestamp(df):
        return
    df = remove_duplicates(df)
    df = fix_value_column(df)
    save_data(df, "corrected_time_series.csv")

    #---Part B---
    input_file = "corrected_time_series.csv"
    df = load_data(input_file)
    if df is None:
        return
    hourly_avg = calc_hourly_avg(df)
    if hourly_avg is not None:
        save_data(hourly_avg, "hourly_average.csv")


if __name__ == "__main__":
    main()


