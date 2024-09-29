namespace BadgeGenerator;

public class BadgeContent
{
	public bool IsUrl => Address is not null;

	public int Length => Address is not null ? Address.ToString().Length : Text!.Length;

	private string? Text { get; }

	private Uri? Address { get; }

	public BadgeContent(Uri address)
	{
		Address = address;
	}

	public BadgeContent(string name)
	{
		Text = name;
	}

	public static implicit operator BadgeContent(string text)
	{
		return new BadgeContent(text);
	}

	public static implicit operator BadgeContent(Uri address)
	{
		return new BadgeContent(address);
	}

	public override string ToString()
	{
		return Address is not null ? Address.ToString() : Text!;
	}

}
